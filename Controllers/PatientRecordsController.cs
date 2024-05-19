using apiTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiTask.Controllers
{
    public class PatientRecordsController : ApiController
    {
        // POST api/patientrecords
        [HttpPost]
        public IHttpActionResult Post([FromBody] PatientRecord record)
        {
            // Check if the record object is null or any required field is empty
            if (record == null || record.PatientId == 0 || string.IsNullOrEmpty(record.Diagnosis) || record.DateOfDiagnosis == null)
            {
                return BadRequest(); // If any field is null or empty, return BadRequest
            }

            // Implement logic to add patient record to the database
            using (var dbContext = new DatabaseContext())
            {
                // Add the new record to the database
                dbContext.PatientRecords.Add(record);
                dbContext.SaveChanges();

                return Created("api/patientrecords/" + record.Id, record); // Record added successfully, return Created with record data
            }
        }
    }

}
