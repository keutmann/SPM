// -----------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
#if CLR40
    [Serializable]
#endif
    public class Lazy<T, TMetadata> : Lazy<T>
    {
        private TMetadata _metadata;

        public Lazy(Func<T> valueFactory, TMetadata metadata) : 
            base(valueFactory)
        {
            this._metadata = metadata;
        }

        public Lazy(TMetadata metadata) :
            base()
        {
            this._metadata = metadata;
        }


        public Lazy(TMetadata metadata, bool isThreadSafe) : 
            base(isThreadSafe)
        {
            this._metadata = metadata;
        }

        public Lazy(Func<T> valueFactory, TMetadata metadata, bool isThreadSafe) :
            base(valueFactory, isThreadSafe)
        {
            this._metadata = metadata;
        }

#if CLR40
        [System.Security.SecuritySafeCritical]
        protected Lazy(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
            base(info, context)
        {
            this._metadata = (TMetadata)info.GetValue("Metadata", typeof(TMetadata));
        }

        [System.Security.SecurityCritical]
        protected override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Metadata", this._metadata);
        }
#endif

        public TMetadata Metadata
        {
            get
            {
                return this._metadata;
            }
        }
    }
}
