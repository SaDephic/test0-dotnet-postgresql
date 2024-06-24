using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace test0_dotnet_postgresql
{
    public partial class Employee : IEquatable<Employee>
    {
        [Key]
        public int Id { get; set; }
        public int Department_id { get; set; }
        public int? Chief_id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Employee {\n");
            sb.Append("  ID: ").Append(Id).Append("\n");
            sb.Append("  Chief_id: ").Append(Chief_id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Employee)obj);
        }
        public bool Equals(Employee other)
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
                    Department_id == other.Department_id ||
                    Department_id != null &&
                    Department_id.Equals(other.Department_id)
                )&&
                (
                    Chief_id == other.Chief_id ||
                    Chief_id != null &&
                    Chief_id.Equals(other.Chief_id)
                )&&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.SequenceEqual(other.Name)
                )&&
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
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Employee left, Employee right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Employee left, Employee right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}