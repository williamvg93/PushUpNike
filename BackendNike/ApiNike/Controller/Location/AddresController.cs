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

public class AddresController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddresController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AddressDto>>> Get()
    {
        var addresses = await _unitOfWork.Addresses.GetAllAsync();
        /* return Ok(addresses); */
        return _mapper.Map<List<AddressDto>>(addresses);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddressDto>> Get(int id)
    {
        var address = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        return _mapper.Map<AddressDto>(address);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Address>> Post(AddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);

        this._unitOfWork.Addresses.Add(address);
        await _unitOfWork.SaveAsync();
        if (address == null)
        {
            return BadRequest();
        }
        addressDto.Id = address.Id;
        return CreatedAtAction(nameof(Post), new { id = addressDto.Id }, addressDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddressDto>> Put(int id, [FromBody] AddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);
        if (address.Id == 0)
        {
            address.Id = id;
        }
        if (address.Id != id)
        {
            return BadRequest();
        }
        if (address == null)
        {
            return NotFound();
        }

        addressDto.Id = address.Id;
        _unitOfWork.Addresses.Update(address);
        await _unitOfWork.SaveAsync();
        return addressDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var address = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        _unitOfWork.Addresses.Remove(address);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}