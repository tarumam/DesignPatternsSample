using System;
using System.Collections.Generic;
using System.Text;

namespace Creational.BuilderCodingExerc
{
    public class Field
    {
        public string Type, Name;
        public override string ToString()
        {
            return $"public {Type} {Name}";
        }
    }

    public class NewClass
    {
        public string Name;
        public List<Field> Fields = new List<Field>();

        public NewClass()
        {
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Name}").AppendLine("{");
            foreach (var f in Fields)
                sb.AppendLine($"  {f};");
            sb.AppendLine("}");
            return sb.ToString();
        }

    }
    public class CodeBuilder
    {
        protected NewClass newClass = new NewClass();

        public CodeBuilder(string objName)
        {
            newClass.Name = objName;
        }

        public CodeBuilder AddField(string name, string type)
        {
            newClass.Fields.Add(new Field { Name = name, Type = type });
            return this;
        }

        public override string ToString()
        {
            return newClass.ToString();
        }
    }

    public class BuilderCodingExercise
    {
        public BuilderCodingExercise()
        {
            var code = new CodeBuilder("Person").AddField("Name", "string").AddField("age", "int");
            Console.WriteLine(code);
        }
    }
}
