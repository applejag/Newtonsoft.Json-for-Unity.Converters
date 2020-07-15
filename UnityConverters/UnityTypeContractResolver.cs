using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters
{
    public class UnityTypeContractResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            List<MemberInfo> members = base.GetSerializableMembers(objectType);

            members.AddRange(GetMissingMembers(objectType, members));

            return members;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty jsonProperty = base.CreateProperty(member, memberSerialization);

            if (member.GetCustomAttribute<SerializeField>() != null)
            {
                jsonProperty.Ignored = false;
                jsonProperty.Writable = CanWriteMemberWithSerializeField(member);
                jsonProperty.Readable = CanReadMemberWithSerializeField(member);
                jsonProperty.HasMemberAttribute = true;
            }

            return jsonProperty;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> lists = base.CreateProperties(type, memberSerialization);

            return lists;
        }

        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract jsonObjectContract = base.CreateObjectContract(objectType);

            if (typeof(ScriptableObject).IsAssignableFrom(objectType))
            {
                jsonObjectContract.DefaultCreator = () =>
                {
                    return ScriptableObject.CreateInstance(objectType);
                };
            }

            return jsonObjectContract;
        }

        private static IEnumerable<MemberInfo> GetMissingMembers(Type type, List<MemberInfo> alreadyAdded)
        {
            return type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
                .Cast<MemberInfo>()
                .Concat(type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
                .Where(o => o.GetCustomAttribute<SerializeField>() != null
                    && !alreadyAdded.Contains(o));
        }

        private static bool CanReadMemberWithSerializeField(MemberInfo member)
        {
            if (member is PropertyInfo property)
            {
                return property.CanRead;
            }
            else
            {
                return true;
            }
        }

        private static bool CanWriteMemberWithSerializeField(MemberInfo member)
        {
            if (member is PropertyInfo property)
            {
                return property.CanWrite;
            }
            else
            {
                return true;
            } 
        }
    }
}
