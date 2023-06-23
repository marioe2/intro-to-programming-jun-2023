using System.Xml.Linq;

namespace Greeter
{
    public class GreetingMaker
    {
        public IBlackList _blackList;
        public INotification _notification;

        public GreetingMaker(IBlackList blackList, INotification notification)
        {
            _blackList = blackList;
            _notification = notification;  
        }

        /*        public string Greet(string? name, params string[] rest)
                {
                    if (name == null)
                    {
                        return "Hello, Chief!";
                    }

                    if (IsAllUpper(name))
                    {
                        return $"Hello, {name}!".ToUpper();
                    }

                    return $"Hello, {name}.";
                }*/

        public string Greet(params string[]? names)
        {
            var greeting = "Hello";
            var nameString = "";

            if (names == null)
            {
                return "Hello, Chief!";
            }

            if (names.Length == 1)
            {
                if (IsAllUpper(names[0]))
                {
                    return $"Hello, {names[0]}!".ToUpper();
                }
                else
                {
                    return $"Hello, {names[0]}.";
                }
            }

            if (names.Length == 2)
            {
                foreach (string name in names)
                {
                    if (IsAllUpper(name))
                    {
                        greeting += $", {name}".ToUpper();
                    }
                    else if (name == names.Last())
                    {
                        greeting += $" and {name}";
                    }
                    else
                    {
                        greeting += $", {name}";
                    }
                }
            }

            else
            {
                foreach (string name in names)
                {
                    if (!IsAllUpper(name) && name == names.Last())
                    {
                        nameString += $", and {name}";
                    }
                    else if (IsAllUpper(name) && name == names.Last())
                    {
                        nameString += $", AND {name}";
                    }
                    else if (IsAllUpper(name))
                    {
                        nameString += $", {name}";
                    }
                    else
                    {
                        nameString += $", {name}";
                    }
                }

                if (IsAllUpper(nameString))
                {
                    return greeting.ToUpper() + nameString + "!";
                }
            }

            return greeting + nameString + "!";
            
        }

        public bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                    return false;
            }
            return true;
        }
    }

    public interface INotification
    {
    }

    public interface IBlackList
    {
        object Check(string name);
    }
}

