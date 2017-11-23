namespace ShareFlow.Domain.Tools
{
    /// <summary>
    /// Extension class for string type
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Used to replace accented characters from a string source to character equivalent without accent
        /// </summary>
        /// <param name="stringSource">String source</param>
        /// <returns>the updated original string</returns>
        public static string ReplaceAccentedCharacter(this string stringSource)
        {
            //>Init
            string CHAINE_AVEC_ACCENT = "ÀÁÂÃÄÅàáâãäåÒÓÔÕÖØòóôõöøÈÉÊËèéêëÌÍÎÏìíîïÙÚÛÜùúûüÿÑñÇç";
            string CHAINE_SANS_ACCENT = "AAAAAAaaaaaaOOOOOOooooooEEEEeeeeIIIIiiiiUUUUuuuuyNnCc";

            int li32Compteur = 0;
            string lstrLettre = string.Empty;

            //>Traitment
            for (li32Compteur = 1; li32Compteur < CHAINE_AVEC_ACCENT.Length; li32Compteur++)
            {
                lstrLettre = CHAINE_AVEC_ACCENT.Substring(li32Compteur, 1);
                if (stringSource.Contains(lstrLettre))
                {
                    stringSource = stringSource.Replace(lstrLettre, CHAINE_SANS_ACCENT.Substring(li32Compteur, 1));
                }
            }

            //>Return
            return stringSource;
        }
    }
}