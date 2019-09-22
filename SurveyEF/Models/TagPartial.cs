using SurveyEF.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyEF.Models
{
    internal partial class Tag
    {
        internal int Gravar()
        {
            if (this.Id == 0 && this.Nome.Length > 0)
                return new TagDAO().Gravar(this);
            else
                return -10;
        }
    }
}
