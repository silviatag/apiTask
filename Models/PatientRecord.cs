using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiTask.Models
{
    public class PatientRecord
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        public string Diagnosis { get; set; }
        public DateTime DateOfDiagnosis { get; set; }

        // Default constructor
        public PatientRecord()
        {
        }

        // Constructor with parameters
        public PatientRecord(long patientId, string diagnosis, DateTime dateOfDiagnosis)
        {
            PatientId = patientId;
            Diagnosis = diagnosis;
            DateOfDiagnosis = dateOfDiagnosis;
        }
    }
}