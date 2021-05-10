using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drop.Web.models;

namespace Drop.Web.ViewModels
{
    public class DonorViewQuestionViewModel
    {
        public enum Answers
        {
            Yes,
            No,
        }

        public DropDatabaseContext dropDatabaseContext { get; set; }
        public Answers answer { get; set; }
    }
}
