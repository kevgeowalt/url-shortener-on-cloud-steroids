namespace shared.Helpers
{
    public static class Environmentmaster
    {
        public static void LoadEnvironmentVariables(string path)
        {
            if (!File.Exists(path)) return;

            var data = File.ReadAllLines(path);

            for (int i = 0; i < data.Length; i++)
            {
                var currentLine = data[i];
                var sections = currentLine.Split(new char[] { '=' }, 2, StringSplitOptions.RemoveEmptyEntries);

                if (sections.Length != 2) continue;

                Environment.SetEnvironmentVariable(sections[0], sections[1]);
            }
        }
    }
}