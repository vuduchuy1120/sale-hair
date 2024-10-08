﻿using System.Text;

namespace SaleRazorPage.Utils
{
    public static class RemoveAccent
    {
        private static readonly Dictionary<char, char> VietnameseChars = new Dictionary<char, char>
        {
            {'á', 'a'}, {'à', 'a'}, {'ạ', 'a'}, {'ả', 'a'}, {'ã', 'a'}, {'â', 'a'}, {'ấ', 'a'}, {'ầ', 'a'}, {'ậ', 'a'}, {'ẩ', 'a'}, {'ẫ', 'a'}, {'ă', 'a'}, {'ắ', 'a'}, {'ằ', 'a'}, {'ặ', 'a'}, {'ẳ', 'a'}, {'ẵ', 'a'},
            {'Á', 'A'}, {'À', 'A'}, {'Ạ', 'A'}, {'Ả', 'A'}, {'Ã', 'A'}, {'Â', 'A'}, {'Ấ', 'A'}, {'Ầ', 'A'}, {'Ậ', 'A'}, {'Ẩ', 'A'}, {'Ẫ', 'A'}, {'Ă', 'A'}, {'Ắ', 'A'}, {'Ằ', 'A'}, {'Ặ', 'A'}, {'Ẳ', 'A'}, {'Ẵ', 'A'},
            {'é', 'e'}, {'è', 'e'}, {'ẹ', 'e'}, {'ẻ', 'e'}, {'ẽ', 'e'}, {'ê', 'e'}, {'ế', 'e'}, {'ề', 'e'}, {'ệ', 'e'}, {'ể', 'e'}, {'ễ', 'e'},
            {'É', 'E'}, {'È', 'E'}, {'Ẹ', 'E'}, {'Ẻ', 'E'}, {'Ẽ', 'E'}, {'Ê', 'E'}, {'Ế', 'E'}, {'Ề', 'E'}, {'Ệ', 'E'}, {'Ể', 'E'}, {'Ễ', 'E'},
            {'ó', 'o'}, {'ò', 'o'}, {'ọ', 'o'}, {'ỏ', 'o'}, {'õ', 'o'}, {'ô', 'o'}, {'ố', 'o'}, {'ồ', 'o'}, {'ộ', 'o'}, {'ổ', 'o'}, {'ỗ', 'o'}, {'ơ', 'o'}, {'ớ', 'o'}, {'ờ', 'o'}, {'ợ', 'o'}, {'ở', 'o'}, {'ỡ', 'o'},
            {'Ó', 'O'}, {'Ò', 'O'}, {'Ọ', 'O'}, {'Ỏ', 'O'}, {'Õ', 'O'}, {'Ô', 'O'}, {'Ố', 'O'}, {'Ồ', 'O'}, {'Ộ', 'O'}, {'Ổ', 'O'}, {'Ỗ', 'O'}, {'Ơ', 'O'}, {'Ớ', 'O'}, {'Ờ', 'O'}, {'Ợ', 'O'}, {'Ở', 'O'}, {'Ỡ', 'O'},
            {'ú', 'u'}, {'ù', 'u'}, {'ụ', 'u'}, {'ủ', 'u'}, {'ũ', 'u'}, {'ư', 'u'}, {'ứ', 'u'}, {'ừ', 'u'}, {'ự', 'u'}, {'ử', 'u'}, {'ữ', 'u'},
            {'Ú', 'U'}, {'Ù', 'U'}, {'Ụ', 'U'}, {'Ủ', 'U'}, {'Ũ', 'U'}, {'Ư', 'U'}, {'Ứ', 'U'}, {'Ừ', 'U'}, {'Ự', 'U'}, {'Ử', 'U'}, {'Ữ', 'U'},
            {'í', 'i'}, {'ì', 'i'}, {'ị', 'i'}, {'ỉ', 'i'}, {'ĩ', 'i'},
            {'Í', 'I'}, {'Ì', 'I'}, {'Ị', 'I'}, {'Ỉ', 'I'}, {'Ĩ', 'I'},
            {'đ', 'd'}, {'Đ', 'D'},
            {'ý', 'y'}, {'ỳ', 'y'}, {'ỵ', 'y'}, {'ỷ', 'y'}, {'ỹ', 'y'},
            {'Ý', 'Y'}, {'Ỳ', 'Y'}, {'Ỵ', 'Y'}, {'Ỷ', 'Y'}, {'Ỹ', 'Y'}
        };

        public static string RemoveDiacritics(string text)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                if (VietnameseChars.TryGetValue(c, out char withoutDiacritic))
                {
                    sb.Append(withoutDiacritic);
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
