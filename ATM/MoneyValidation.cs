
namespace ATM
{
    public class MoneyValidation
    {
        public static bool CorrectNotesAndMoneyAmount(Money money)
        {
            if (money.Amount == money.Notes[PaperNote.FiveEuro] * 5 + money.Notes[PaperNote.TenEuro] * 10
                + money.Notes[PaperNote.TwentyEuro] * 20 + money.Notes[PaperNote.FiftyEuro] * 50)
                return true;
            return false;
        }
    }
}
