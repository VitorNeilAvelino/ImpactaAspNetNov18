﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Dominio;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            var veiculo = new VeiculoPasseio();
            veiculo.Ano = 2014;
            veiculo.Cambio = Cambio.Manual;
            veiculo.Carroceria = Carroceria.Hatch;
            veiculo.Combustivel = Combustivel.Flex;
            veiculo.Observacao = "Observação";
            veiculo.Placa = "ABC1234";

            veiculo.Cor = new CorRepositorio().Selecionar(1);
            veiculo.Modelo = new ModeloRepositorio().Selecionar(1);

            new VeiculoRepositorio().Inserir(veiculo);
        }
    }
}