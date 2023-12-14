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

public class ContactController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContactDto>>> Get()
    {
        var contacts = await _unitOfWork.Contacts.GetAllAsync();
        /* return Ok(contacts); */
        return _mapper.Map<List<ContactDto>>(contacts);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContactDto>> Get(int id)
    {
        var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        return _mapper.Map<ContactDto>(contact);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contact>> Post(ContactDto contactDto)
    {
        var contact = _mapper.Map<Contact>(contactDto);

        this._unitOfWork.Contacts.Add(contact);
        await _unitOfWork.SaveAsync();
        if (contact == null)
        {
            return BadRequest();
        }
        contactDto.Id = contact.Id;
        return CreatedAtAction(nameof(Post), new { id = contactDto.Id }, contactDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContactDto>> Put(int id, [FromBody] ContactDto contactDto)
    {
        var contact = _mapper.Map<Contact>(contactDto);
        if (contact.Id == 0)
        {
            contact.Id = id;
        }
        if (contact.Id != id)
        {
            return BadRequest();
        }
        if (contact == null)
        {
            return NotFound();
        }

        contactDto.Id = contact.Id;
        _unitOfWork.Contacts.Update(contact);
        await _unitOfWork.SaveAsync();
        return contactDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
        if (contact == null)
        {
            return NotFound();
        }
        _unitOfWork.Contacts.Remove(contact);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}