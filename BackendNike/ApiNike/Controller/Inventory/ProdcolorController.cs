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

public class ProdcolorController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProdcolorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProdcolorDto>>> Get()
    {
        var prodColors = await _unitOfWork.ProductColors.GetAllAsync();
        /* return Ok(prodColors); */
        return _mapper.Map<List<ProdcolorDto>>(prodColors);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProdcolorDto>> Get(int id)
    {
        var prodColor = await _unitOfWork.ProductColors.GetByIdAsync(id);
        if (prodColor == null)
        {
            return NotFound();
        }
        return _mapper.Map<ProdcolorDto>(prodColor);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Prodcolor>> Post(ProdcolorDto prodcolorDto)
    {
        var prodColor = _mapper.Map<Prodcolor>(prodcolorDto);

        this._unitOfWork.ProductColors.Add(prodColor);
        await _unitOfWork.SaveAsync();
        if (prodColor == null)
        {
            return BadRequest();
        }
        prodcolorDto.Id = prodColor.Id;
        return CreatedAtAction(nameof(Post), new { id = prodcolorDto.Id }, prodcolorDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProdcolorDto>> Put(int id, [FromBody] ProdcolorDto prodcolorDto)
    {
        var prodColor = _mapper.Map<Prodcolor>(prodcolorDto);
        if (prodColor.Id == 0)
        {
            prodColor.Id = id;
        }
        if (prodColor.Id != id)
        {
            return BadRequest();
        }
        if (prodColor == null)
        {
            return NotFound();
        }

        prodcolorDto.Id = prodColor.Id;
        _unitOfWork.ProductColors.Update(prodColor);
        await _unitOfWork.SaveAsync();
        return prodcolorDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var prodColor = await _unitOfWork.ProductColors.GetByIdAsync(id);
        if (prodColor == null)
        {
            return NotFound();
        }
        _unitOfWork.ProductColors.Remove(prodColor);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}