namespace Excersize_5_Lexicon.Extras
{
    static class MyExtensions
    {
        public static char[] ToLower(this char[] ch)
        {
            for (int i = 0; i < ch.Length; i++)
            {
                ch[i] = char.ToLower(ch[i]);
            }
            return ch;
        }
    }
}
