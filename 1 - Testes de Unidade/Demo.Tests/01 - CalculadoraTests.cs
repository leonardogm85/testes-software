﻿using Xunit;

namespace Demo.Tests
{
    public class CalculadoraTests
    {
        [Fact(DisplayName = "Calculadora - Somar 2 + 2 Deve Ser Igual a 4")]
        [Trait("Categoria", "Testes Basicos - CalculadoraTests")]
        public void Calculadora_Somar_RetornarValorSoma()
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(2, 2);

            // Assert
            Assert.Equal(4, resultado);
        }

        [Theory(DisplayName = "Calculadora - Deve Somar Corretamente Os Valores")]
        [Trait("Categoria", "Testes Basicos - CalculadoraTests")]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(4, 2, 6)]
        [InlineData(7, 3, 10)]
        [InlineData(6, 6, 12)]
        [InlineData(9, 9, 18)]
        public void Calculadora_Somar_RetornarValoresSomaCorretos(double v1, double v2, double total)
        {
            // Arrange
            var calculadora = new Calculadora();

            // Act
            var resultado = calculadora.Somar(v1, v2);

            // Assert
            Assert.Equal(total, resultado);
        }
    }
}
