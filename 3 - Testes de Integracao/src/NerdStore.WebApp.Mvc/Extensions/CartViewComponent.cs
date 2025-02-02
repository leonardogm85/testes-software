﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Vendas.Application.Queries;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NerdStore.WebApp.Mvc.Extensions
{
    public class CartViewComponent : ViewComponent
    {
        private readonly IPedidoQueries _pedidoQueries;

        protected Guid ClienteId;

        public CartViewComponent(
            IPedidoQueries pedidoQueries,
            IHttpContextAccessor httpContextAccessor)
        {
            _pedidoQueries = pedidoQueries;

            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                ClienteId = new Guid(claim.Value);
            }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var carrinho = await _pedidoQueries.ObterCarrinhoCliente(ClienteId);
            var itens = carrinho?.Itens.Count ?? 0;

            return View(itens);
        }
    }
}
