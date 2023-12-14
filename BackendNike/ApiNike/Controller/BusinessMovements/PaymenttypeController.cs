using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNike.Dtos.Get.BusinessMovements;
using AutoMapper;
using Domain.Entities.BusinessMovements;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiNike.Controller.BusinessMovements;

public class PaymenttypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PaymenttypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaymenttypeDto>>> Get()
    {
        var paymentTypes = await _unitOfWork.PaymentTypes.GetAllAsync();
        /* return Ok(paymentTypes); */
        return _mapper.Map<List<PaymenttypeDto>>(paymentTypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaymenttypeDto>> Get(int id)
    {
        var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
        if (paymentType == null)
        {
            return NotFound();
        }
        return _mapper.Map<PaymenttypeDto>(paymentType);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Paymenttype>> Post(PaymenttypeDto paymenttypeDto)
    {
        var paymentType = _mapper.Map<Paymenttype>(paymenttypeDto);

        this._unitOfWork.PaymentTypes.Add(paymentType);
        await _unitOfWork.SaveAsync();
        if (paymentType == null)
        {
            return BadRequest();
        }
        paymenttypeDto.Id = paymentType.Id;
        return CreatedAtAction(nameof(Post), new { id = paymenttypeDto.Id }, paymenttypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymenttypeDto>> Put(int id, [FromBody] PaymenttypeDto paymenttypeDto)
    {
        var paymentType = _mapper.Map<Paymenttype>(paymenttypeDto);
        if (paymentType.Id == 0)
        {
            paymentType.Id = id;
        }
        if (paymentType.Id != id)
        {
            return BadRequest();
        }
        if (paymentType == null)
        {
            return NotFound();
        }

        paymenttypeDto.Id = paymentType.Id;
        _unitOfWork.PaymentTypes.Update(paymentType);
        await _unitOfWork.SaveAsync();
        return paymenttypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var paymentType = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
        if (paymentType == null)
        {
            return NotFound();
        }
        _unitOfWork.PaymentTypes.Remove(paymentType);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}