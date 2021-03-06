﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RentApp.Models.Entities;
using RentApp.Persistance;
using RentApp.Persistance.UnitOfWork;

namespace RentApp.Controllers
{
    public class PriceItemsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public PriceItemsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<PriceItem> GetPriceItems()
        {
            return unitOfWork.PriceItems.GetAll();
        }

        [ResponseType(typeof(PriceItem))]
        public IHttpActionResult GetPriceItem(int id)
        {
            PriceItem priceItem = unitOfWork.PriceItems.Get(id);
            if (priceItem == null)
            {
                return NotFound();
            }

            return Ok(priceItem);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutPriceItem(int id, PriceItem priceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != priceItem.Id)
            {
                return BadRequest();
            }

            try
            {
                unitOfWork.PriceItems.Update(priceItem);
                unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriceItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(PriceItem))]
        public IHttpActionResult PostPriceItem(PriceItem priceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            unitOfWork.PriceItems.Add(priceItem);
            unitOfWork.Complete();

            return CreatedAtRoute("DefaultApi", new { id = priceItem.Id }, priceItem);
        }

        [ResponseType(typeof(PriceItem))]
        public IHttpActionResult DeletePriceItem(int id)
        {
            PriceItem priceItem = unitOfWork.PriceItems.Get(id);
            if (priceItem == null)
            {
                return NotFound();
            }

            unitOfWork.PriceItems.Remove(priceItem);
            unitOfWork.Complete();

            return Ok(priceItem);
        }

        private bool PriceItemExists(int id)
        {
            return unitOfWork.PriceItems.Get(id) != null;
        }
    }
}