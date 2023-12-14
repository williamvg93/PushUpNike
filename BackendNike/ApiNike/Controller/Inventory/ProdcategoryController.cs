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

public class ProdcategoryController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProdcategoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProdcategoryDto>>> Get()
    {
        var prodCategories = await _unitOfWork.ProductCategories.GetAllAsync();
        /* return Ok(prodCategories); */
        return _mapper.Map<List<ProdcategoryDto>>(prodCategories);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProdcategoryDto>> Get(int id)
    {
        var prodCategory = await _unitOfWork.ProductCategories.GetByIdAsync(id);
        if (prodCategory == null)
        {
            return NotFound();
        }
        return _mapper.Map<ProdcategoryDto>(prodCategory);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Prodcategory>> Post(ProdcategoryDto prodcategoryDto)
    {
        var prodCategory = _mapper.Map<Prodcategory>(prodcategoryDto);

        this._unitOfWork.ProductCategories.Add(prodCategory);
        await _unitOfWork.SaveAsync();
        if (prodCategory == null)
        {
            return BadRequest();
        }
        prodcategoryDto.Id = prodCategory.Id;
        return CreatedAtAction(nameof(Post), new { id = prodcategoryDto.Id }, prodcategoryDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProdcategoryDto>> Put(int id, [FromBody] ProdcategoryDto prodcategoryDto)
    {
        var prodCategory = _mapper.Map<Prodcategory>(prodcategoryDto);
        if (prodCategory.Id == 0)
        {
            prodCategory.Id = id;
        }
        if (prodCategory.Id != id)
        {
            return BadRequest();
        }
        if (prodCategory == null)
        {
            return NotFound();
        }

        prodcategoryDto.Id = prodCategory.Id;
        _unitOfWork.ProductCategories.Update(prodCategory);
        await _unitOfWork.SaveAsync();
        return prodcategoryDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var prodCategory = await _unitOfWork.ProductCategories.GetByIdAsync(id);
        if (prodCategory == null)
        {
            return NotFound();
        }
        _unitOfWork.ProductCategories.Remove(prodCategory);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}