using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNike.Dtos.Get.Location;
using AutoMapper;
using Domain.Entities.Location;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNike.Controller.Location;

public class DepartmentController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get()
    {
        var departments = await _unitOfWork.Departments.GetAllAsync();
        /* return Ok(departments); */
        return _mapper.Map<List<DepartmentDto>>(departments);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartmentDto>> Get(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return _mapper.Map<DepartmentDto>(department);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Department>> Post(DepartmentDto departmentDto)
    {
        var department = _mapper.Map<Department>(departmentDto);

        this._unitOfWork.Departments.Add(department);
        await _unitOfWork.SaveAsync();
        if (department == null)
        {
            return BadRequest();
        }
        departmentDto.Id = department.Id;
        return CreatedAtAction(nameof(Post), new { id = departmentDto.Id }, departmentDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartmentDto>> Put(int id, [FromBody] DepartmentDto departmentDto)
    {
        var department = _mapper.Map<Department>(departmentDto);
        if (department.Id == 0)
        {
            department.Id = id;
        }
        if (department.Id != id)
        {
            return BadRequest();
        }
        if (department == null)
        {
            return NotFound();
        }

        departmentDto.Id = department.Id;
        _unitOfWork.Departments.Update(department);
        await _unitOfWork.SaveAsync();
        return departmentDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        _unitOfWork.Departments.Remove(department);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}