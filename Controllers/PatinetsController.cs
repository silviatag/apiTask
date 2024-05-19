using apiTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiTask.Controllers
{
    public class PatientsController : ApiController
    {
        // GET api/patients/{id}
        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            using (var dbContext = new DatabaseContext())
            {
                var patient = dbContext.Patients.Find(id);
                if (patient != null)
                {
                    return Ok(patient); // Patient found, return Ok with patient data
                }
                else
                {
                    return NotFound(); // Patient not found, return NotFound
                }
            }
        }

        // POST api/patients
        [HttpPost]
        public IHttpActionResult Post([FromBody] Patient patient)
        {
            // Check if the patient object is null or any required field is empty
            if (patient == null || string.IsNullOrEmpty(patient.Name) || patient.BirthDate == null || string.IsNullOrEmpty(patient.NationalId) || string.IsNullOrEmpty(patient.City))
            {
                return BadRequest(); // If any field is null or empty, return BadRequest
            }

            // Check if the NationalId already exists in the database
            using (var dbContext = new DatabaseContext())
            {
                var existingPatient = dbContext.Patients.FirstOrDefault(p => p.NationalId == patient.NationalId);
                if (existingPatient != null)
                {
                    return Conflict(); // If NationalId already exists, return Conflict
                }

                // Add the new patient to the database
                dbContext.Patients.Add(patient);
                dbContext.SaveChanges();

                return Created("api/patients/" + patient.Id, patient); // Patient added successfully, return Created with patient data
            }
        }
    }

}
