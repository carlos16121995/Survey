using SurveyEF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SurveyEF.DAL
{
    internal class TagDAO
    {
        internal int Gravar(Tag tag)
        {
            try
            {
                using(SurveyContext contexto = new SurveyContext())
                {
                    contexto.Tag.Add(tag);
                    return contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
