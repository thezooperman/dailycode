namespace problems
{
    class Problem7
    {
        /*
        Given the mapping a = 1, b = 2, ... z = 26, and an encoded message,
        count the number of ways it can be decoded.

        For example, the message '111' would give 3, since it could be decoded
        as 'aaa', 'ka', and 'ak'.

        You can assume that the messages are decodable. For example, '001' is not allowed.
        */

        private int decoderUtil(string message, int index)
        {
            if (index > message.Length)
                return 0;
            if (message.Length == index)
                return 1;

            int currentNum = int.Parse(message[index].ToString());
            int decodeWays = 0;
            if (currentNum > 0 && currentNum < 27)
                decodeWays += decoderUtil(message, index + 1);

            if (index < message.Length - 1)
            {
                currentNum = int.Parse(message.Substring(index, 2));
                if (currentNum < 27)
                    decodeWays += decoderUtil(message, index + 2);
            }

            return decodeWays;
        }

        public int problem7(string message)
        {
            return decoderUtil(message, 0);
        }
    }
}