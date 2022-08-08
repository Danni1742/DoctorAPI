using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Issue
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string DescriptionShort { get; set; }
        string MedicalCondition { get; set; }
        List<Symptom> PossibleSymptoms { get; set; }
        string ProfName { get; set; }
        string Synonyms { get; set; }
        string TreatmentDescription { get; set; }
        double Accuracy { get; set; }
        string Icd { get; set; }
        string IcdName { get; set; }
        int Ranking { get; set; }
    }
}
