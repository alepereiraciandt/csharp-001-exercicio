using System;

namespace guessing_number;

public class GuessNumber
{
    //In this way we are passing the random number generator by dependency injection
    private IRandomGenerator random;
    public GuessNumber() : this(new DefaultRandom()) { }
    public GuessNumber(IRandomGenerator obj)
    {
        this.random = obj;

        userValue = 0;
        randomValue = 0;
    }

    //user variables
    public int userValue;
    public int randomValue;

    public int maxAttempts = 5;
    public int currentAttempts;

    public int difficultyLevel = 1;

    public bool gameOver;

    //1 - Imprima uma mensagem de saudação
    public string Greet()
    {
        return "---Bem-vindo ao Guessing Game--- /n Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!";
    }

    //2 - Receba a entrada da pessoa usuária e converta para Int
    //5 - Adicione um limite de tentativas
    public string ChooseNumber(string userEntry)
    {
        int userEnter = 0;
        var message = string.Empty;
        var canConvert = Int32.TryParse(userEntry, out userEnter);

        currentAttempts++;

        if (currentAttempts > maxAttempts)
        {
            gameOver = true;
            return "Você excedeu o número máximo de tentativas! Tente novamente.";
        }


        if (canConvert)
        {
            if (userEnter > -100 && userEnter < 100)
            {
                userValue = userEnter;
                message = "Número escolhido!";
            }
            else
            {
                message = "Entrada inválida! Valor não está no range.";
            }
        }
        else
        {
            message = "Entrada inválida! Não é um número.";
        }

        return message;
    }

    //3 - Gere um número aleatório
    public string RandomNumber()
    {
        string message = string.Empty;
        if (maxAttempts > 0)
        {
            randomValue = random.GetInt(-100, 100);

            message = "A máquina escolheu um número de -100 à 100!";
        }
        else
        {
            message = "Você excedeu o número máximo de tentativas!";

        }

        return message;
    }

    //6 - Adicione níveis de dificuldade
    public string RandomNumberWithDifficult()
    {
        int min = 0;
        int max = 0;

        if (difficultyLevel == 1)
        {
            min = -100;
            max = 100;
        }
        else if (difficultyLevel == 2)
        {
            min = -500;
            max = 500;
        }
        else if (difficultyLevel == 3)
        {
            min = -1000;
            max = 1000;
        }


        return $"A máquina escolheu um número de {min} à {max}!";
    }

    //4 - Verifique a resposta da jogada
    public string AnalyzePlay()
    {
        var message = "ACERTOU!";

        if (userValue < randomValue)
        {
            message = "Tente um número MAIOR";
        }
        else if (userValue > randomValue)
        {
            message = "Tente um número MENOR";
        }

        return message;
    }

    //7 - Adicione uma opção para reiniciar o jogo
    public void RestartGame()
    {
        throw new NotImplementedException();
    }
}