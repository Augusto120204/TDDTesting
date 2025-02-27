using System;
using Productos.Models;
using Reqnroll;

namespace ReqnrollTestingProject.StepDefinitions
{
    [Binding]
    public class CirculoStepDefinitions
    {
        private readonly Circulo _circulo = new Circulo();
        private double _resultado;

        [Given("El radio es {double}")]
        public void GivenElRadioEs(double radio)
        {
            _circulo.Radio = radio;
        }

        [When("El radio se esta calculando")]
        public void WhenElRadioSeEstaCalculando()
        {
            _resultado = _circulo.CalcularArea();
        }

        [Then("El area es {double}")]
        public void ThenElAreaEs(double resultado)
        {
            _resultado.CompareTo(resultado);
        }
    }
}
