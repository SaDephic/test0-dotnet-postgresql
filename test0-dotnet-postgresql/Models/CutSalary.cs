using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace test0_dotnet_postgresql
{
    public partial class CutSalary : IEquatable<CutSalary>
    {
        [Key]
        public int Id { get; set; }
        public string Department_name { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CutSalary {\n");
            sb.Append("  ID: ").Append(Id).Append("\n");
            sb.Append("  Department_name: ").Append(Department_name).Append("\n");
            sb.Append("  Salary: ").Append(Salary).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CutSalary)obj);
        }
        public bool Equals(CutSalary other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Department_name == other.Department_name ||
                    Department_name != null &&
                    Department_name.SequenceEqual(other.Department_name)
                ) &&
                (
                    Salary == other.Salary ||
                    Salary != null &&
                    Salary.Equals(other.Salary)
                );
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Department_name != null)
                    hashCode = hashCode * 59 + Department_name.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CutSalary left, CutSalary right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CutSalary left, CutSalary right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}