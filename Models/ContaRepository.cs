using System;
using System.Collections.Generic;
using System.Linq;

namespace ContadeLuz.Models
{
    public class ContaRepository
    {
        public static List<Conta> contas = new List<Conta>();
    
        public ContaRepository()
        {           
        }

        public void Create(Conta conta)
        {
            contas.Add(conta);
        }
        public List<Conta> GetAll()
        {
            return contas;
        }

        public Conta Maior(){
            List<Conta> contas = GetAll();
            DateTime padrao = new DateTime(2019,01,01);
            if (contas.Count==0){
                Conta vazio = new Conta(0,padrao,0,0,0.0,padrao,0);
                return vazio;
            }
            var Maximo = contas.Max(x=>x.qtdKw);
            return contas.Where(x=>x.qtdKw==Maximo).FirstOrDefault();
        }

        public Conta Menor(){
            List<Conta> contas = GetAll();
            DateTime padrao = new DateTime(2019,01,01);
            if (contas.Count==0){
                Conta vazio = new Conta(0,padrao,0,0,0.0,padrao,0);
                return vazio;
            }
            var Minimo = contas.Min(x=>x.qtdKw);
            return contas.Where(x=>x.qtdKw==Minimo).FirstOrDefault();
        }

        public Conta GetById(int id)
        {
            return contas.Find(i=>i.id == id);
        }
        
        public void Delete(int id)
        {
            contas.Remove(GetById(id));

        }
        public void Update(Conta conta)
        {
            var index  = contas.FindIndex(x=>x.id == conta.id);
            contas[index].dataLeitura = conta.dataLeitura;
            contas[index].numeroLeitura = conta.numeroLeitura;
            contas[index].qtdKw = conta.qtdKw;
            contas[index].valorConta = conta.valorConta;
            contas[index].dataPagamento = conta.dataPagamento;
            contas[index].mediaConsumo = conta.mediaConsumo;
            contas[index].numeroLeitura = conta.numeroLeitura;
        }
    }
}