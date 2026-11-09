namespace Thismaker.JsUnpacker
{
    internal class Unbaser
    {
        private const string Alphanumeric = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private const string HighAscii = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

        private readonly int _base;

        private readonly Dictionary<char, int> _digits;

        public Unbaser(int baseValue)
        {
            if (baseValue < 2 || baseValue > 95)
            {
                throw new ArgumentOutOfRangeException(nameof(baseValue));
            }

            _base = baseValue;

            string alphabet = baseValue <= 62 ? Alphanumeric[..baseValue] : HighAscii;

            _digits = alphabet
                .Select((c, i) => (c, i))
                .ToDictionary(x => x.c, x => x.i);
        }

        public bool TryUnbase(string value, out int result)
        {
            long total = 0;

            foreach (char c in value)
            {
                if (!_digits.TryGetValue(c, out int digit) || digit >= _base)
                {
                    result = 0;
                    return false;
                }

                total = total * _base + digit;

                if (total > int.MaxValue)
                {
                    result = 0;
                    return false;
                }
            }

            result = (int)total;
            return value.Length > 0;
        }

        public int Unbase(string value)
        {
            return TryUnbase(value, out int result) ? result : 0;
        }
    }
}
