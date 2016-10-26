using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace N5D.SOLID
{
    [TestClass]
    public class SingleResponsibilityPrinciple
    {
        [TestMethod]
        public void AClassShouldOnlyHaveOneReasonToChange()
        {
            //A class either does work itself, or knows other classes that do work
        }

        [TestMethod]
        public void A_violation_of_SRP_can_expose_code_to_more_defects_and_create_more_work()
        {
            Violating.Person parent = new Violating.Person();
            Violating.Person principle = new Violating.Person();
            Violating.Person student = new Violating.Person();
            Violating.Person teacher = new Violating.Person();

            var people = new[] { parent, student, principle, teacher };

            NotifyAbsences(people);

            var grades = DoesMathGradeQualify(student);
        }

        private static void NotifyAbsences(Violating.Person[] people)
        {
            foreach (var p in people)
            {
                if (p.IsStudent)
                {
                    foreach (Violating.Person relatedPerson in p.PeopleToNotify)
                    {
                        switch (relatedPerson.Role)
                        {
                            case "Teacher":
                                relatedPerson.NotifyStudentAbsence(p);
                                break;
                            case "Parent":
                                relatedPerson.NotifyChildAbsence(p);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private bool DoesMathGradeQualify(Violating.Person student)
        {
            var grade = student.GetGrade("Math");

            if (grade == null)
                return false;
            if (grade == "A")
                return true;

            return false;
        }
    }
}
