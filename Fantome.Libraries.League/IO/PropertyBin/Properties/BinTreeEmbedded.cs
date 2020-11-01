﻿using System.IO;

namespace Fantome.Libraries.League.IO.PropertyBin.Properties
{
    public sealed class BinTreeEmbedded : BinTreeStructure
    {
        public override BinPropertyType Type => BinPropertyType.Embedded;

        internal BinTreeEmbedded(BinaryReader br, IBinTreeParent parent, uint nameHash) : base(br, parent, nameHash) { }

        public override bool Equals(BinTreeProperty other)
        {
            if (this.NameHash != other.NameHash) return false;

            if (other is BinTreeEmbedded otherProperty)
            {
                if (this.MetaClassHash != otherProperty.MetaClassHash) return false;
                if (this._properties.Count != otherProperty._properties.Count) return false;

                for (int i = 0; i < this._properties.Count; i++)
                {
                    if (!this._properties[i].Equals(otherProperty._properties[i])) return false;
                }
            }

            return true;
        }
    }
}