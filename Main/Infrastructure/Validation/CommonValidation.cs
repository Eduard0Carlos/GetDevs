using Shared.Factory;
using Shared.Results;
using System.Text.RegularExpressions;

namespace Infrastructure.Validation
{
    public class CommonValidation
    {
		public static Result ValidateCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return ResultFactory.CreateFailureResult();
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			cnpj.EndsWith(digito);
			return ResultFactory.CreateSuccessResult();
		}

		public static Result ValidateCep(string cep)
		{
			if (cep.Length == 8)
				cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
			
			if (Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}")))
				return ResultFactory.CreateSuccessResult();
			
			return ResultFactory.CreateFailureResult();
		}
	}
}
