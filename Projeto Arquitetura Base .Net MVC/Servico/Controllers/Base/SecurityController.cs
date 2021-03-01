using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Servico.Controllers.Base
{

    //Utilizado para integração com token de acesso
    public class SecurityController : ApiController
    {

        //private TokenRepository tokenRepository;
        //public Integradora integradora;

        public SecurityController(DbContext context)
        {
            //tokenRepository = new TokenRepository(context);
        }

        public override Task<HttpResponseMessage> ExecuteAsync(System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Threading.CancellationToken cancellationToken)
        {
            var token = System.Web.HttpContext.Current.Request["token"];
            var erro = "";
            if (token != null)
            {
                Guid numero = Guid.Empty;
                if (Guid.TryParse(token, out numero))
                {
                    /*
                    var _token = tokenRepository.GetByExpression(t => t.Numero.CompareTo(numero) == 0).FirstOrDefault();
                    if (_token != null)
                    {
                        if (_token.DataValidade >= DateTime.Now)
                        {
                            integradora = _token.Integradora;
                            return base.ExecuteAsync(controllerContext, cancellationToken);
                        }
                        else
                        {
                            erro = "Token expirou.";
                        }
                    }
                    else
                    {
                        erro = "Token inválido.";
                    }
                    */
                }
                else
                {
                    erro = "Token inválido.";
                }
            }
            else
            {
                erro = "É necessário informar o Token.";
            }

            return Task.Run<HttpResponseMessage>(() => new HttpResponseMessage(HttpStatusCode.Unauthorized)
            {
                Content = new StringContent(erro)
            });
        }

    }
}
