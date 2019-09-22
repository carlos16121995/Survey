using SurveyEF.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SurveyEF.DAL
{
    internal class PerguntaDAO
    {
        internal int Gravar(Pergunta p)
        {
            try
            {
                using (SurveyContext contexto = new SurveyContext())
                {
                    if (p.PerguntaTag != null && p.PerguntaTag.Count > 0)
                {
                    foreach (PerguntaTag pt in p.PerguntaTag)
                        if (pt.IdTagNavigation.Id > 0)
                            contexto.Tag.Attach(pt.IdTagNavigation);
                }
                    contexto.Add(p);
                    return contexto.SaveChanges();
                }
            }
            catch
            {
                return -1;
            }
        }
        internal int Excluir(Pergunta p)
        {
            try
            {
                using(SurveyContext contexto = new SurveyContext())
                {
                    contexto.Pergunta.Attach(p);
                    List<PerguntaTag> aux = p.PerguntaTag.ToList();
                    if(aux != null)
                    {
                        aux.ForEach(pt => p.PerguntaTag.Remove(pt));
                    }
                    contexto.Pergunta.Remove(p);
                   
                    return contexto.SaveChanges();
                }

            }
            catch
            {
                return -1;
            }
        }
       

    }
}
