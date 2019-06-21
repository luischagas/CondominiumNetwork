using System;

namespace CondominiumNetwork.DomainModel.ValueObjects
{
    public struct Category : IComparable<Category>
    {
        public string Description { get; set; }

        public Category(string description)
        {
            if (description.Length < 3)
                throw new ArgumentOutOfRangeException("Category must be more than three characters length.");

            Description = description;
        }

        public static implicit operator String(Category category)
        {
            return category.Description;
        }


        public static implicit operator Category(string category)
        {
            return new Category(category);
        }

        public static bool operator == (Category category1, Category category2)
        {
            if (category1.Description == category2.Description)
                return true;
            return false;
        }

        public static bool operator != (Category category1, Category category2)
        {
            if (category1.Description != category2.Description)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return this.Description.GetHashCode();
        }

        public override string ToString()
        {
            return Description;
        }

        public int CompareTo(Category other)
        {
            return this.Description.CompareTo(other.Description);
        }
    }
}
