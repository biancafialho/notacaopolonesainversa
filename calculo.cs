using System;
using System.Collections.Generic;

namespace questaopolonesainversa
{
    class Program
    {   
        private static float operacao(string operador, float x, float y){
            if(operador == "+"){
                return x+y;
            }
            if(operador == "-"){
                return x-y;
            }
            if(operador == "*"){
                return x*y;
            }
            else{
                return x/y;
            }
        } 


        private static float calcula_polonesa_inversa(string posf2){
            var pol = posf2.Split(" ");
            List<string> operadores = new List<string>{"+",  "-",  "*",  "/"};
            Stack<float> calculo = new Stack<float>();
            for (int i= 0; i< pol.Length; i++){
                float number;
               if (float.TryParse(pol[i], out number)){ // verifica se é numero e se for verdade o retorna
                   calculo.Push(number); // insere o número na pilha
               }
               if(operadores.Contains(pol[i])){
                   float a= calculo.Pop();
                   float b= calculo.Pop();
                   float result = operacao(pol[i],b,a);
                   calculo.Push(result);
               }

            }

            return calculo.Pop();
        }
        static void Main( )
        {
            string posf = "12 5 * 2 3 * - 8 2 * /";
            float resultado = calcula_polonesa_inversa(posf);
            Console.WriteLine(resultado);
        }
    }
}
