using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNike.Dtos.Get.Inventory;
using AutoMapper;
using Domain.Entities.Inventory;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNike.Controller.Inventory;

public class GendertypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GendertypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GendertypeDto>>> Get()
    {
        var genderTypes = await _unitOfWork.GenderTypes.GetAllAsync();
        /* return Ok(genderTypes); */
        return _mapper.Map<List<GendertypeDto>>(genderTypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GendertypeDto>> Get(int id)
    {
        var genderType = await _unitOfWork.GenderTypes.GetByIdAsync(id);
        if (genderType == null)
        {
            return NotFound();
        }
        return _mapper.Map<GendertypeDto>(genderType);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Gendertype>> Post(GendertypeDto gendertypeDto)
    {
        var genderType = _mapper.Map<Gendertype>(gendertypeDto);

        this._unitOfWork.GenderTypes.Add(genderType);
        await _unitOfWork.SaveAsync();
        if (genderType == null)
        {
            return BadRequest();
        }
        gendertypeDto.Id = genderType.Id;
        return CreatedAtAction(nameof(Post), new { id = gendertypeDto.Id }, gendertypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GendertypeDto>> Put(int id, [FromBody] GendertypeDto gendertypeDto)
    {
        var genderType = _mapper.Map<Gendertype>(gendertypeDto);
        if (genderType.Id == 0)
        {
            genderType.Id = id;
        }
        if (genderType.Id != id)
        {
            return BadRequest();
        }
        if (genderType == null)
        {
            return NotFound();
        }

        gendertypeDto.Id = genderType.Id;
        _unitOfWork.GenderTypes.Update(genderType);
        await _unitOfWork.SaveAsync();
        return gendertypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var genderType = await _unitOfWork.GenderTypes.GetByIdAsync(id);
        if (genderType == null)
        {
            return NotFound();
        }
        _unitOfWork.GenderTypes.Remove(genderType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}