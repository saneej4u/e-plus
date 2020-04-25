using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class DoctorWithTitles : BaseSpecification<Doctor>
    {
        public DoctorWithTitles()
        {
            AddInclude(x => x.Title);
        }

        public DoctorWithTitles(int id) : base(x => x.Id == id)
        {
             AddInclude(x => x.Title);
        }
    }
}