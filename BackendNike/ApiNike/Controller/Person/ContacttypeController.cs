using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNike.Dtos.Get.Person;
using AutoMapper;
using Domain.Entities.Person;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNike.Controller.Person;

public class ContacttypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContacttypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContacttypeDto>>> Get()
    {
        var contactTypes = await _unitOfWork.ContactTypes.GetAllAsync();
        /* return Ok(contactTypes); */
        return _mapper.Map<List<ContacttypeDto>>(contactTypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContacttypeDto>> Get(int id)
    {
        var contactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        if (contactType == null)
        {
            return NotFound();
        }
        return _mapper.Map<ContacttypeDto>(contactType);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contacttype>> Post(ContacttypeDto contacttypeDto)
    {
        var contactType = _mapper.Map<Contacttype>(contacttypeDto);

        this._unitOfWork.ContactTypes.Add(contactType);
        await _unitOfWork.SaveAsync();
        if (contactType == null)
        {
            return BadRequest();
        }
        contacttypeDto.Id = contactType.Id;
        return CreatedAtAction(nameof(Post), new { id = contacttypeDto.Id }, contacttypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContacttypeDto>> Put(int id, [FromBody] ContacttypeDto contacttypeDto)
    {
        var contactType = _mapper.Map<Contacttype>(contacttypeDto);
        if (contactType.Id == 0)
        {
            contactType.Id = id;
        }
        if (contactType.Id != id)
        {
            return BadRequest();
        }
        if (contactType == null)
        {
            return NotFound();
        }

        contacttypeDto.Id = contactType.Id;
        _unitOfWork.ContactTypes.Update(contactType);
        await _unitOfWork.SaveAsync();
        return contacttypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var contactType = await _unitOfWork.ContactTypes.GetByIdAsync(id);
        if (contactType == null)
        {
            return NotFound();
        }
        _unitOfWork.ContactTypes.Remove(contactType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}