﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

namespace bibModelWitkowski.Model
{

    // 
    // This source code was auto-generated by xsd, Version=4.8.9037.0.
    // 


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Autorzy
    {

        private AutorzyAutor[] autorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Autor")]
        public AutorzyAutor[] Autor
        {
            get
            {
                return this.autorField;
            }
            set
            {
                this.autorField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.9037.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class AutorzyAutor
    {

        private int idField;

        private string nazwiskoField;

        private string imieField;

        private ushort rokUrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nazwisko
        {
            get
            {
                return this.nazwiskoField;
            }
            set
            {
                this.nazwiskoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string imie
        {
            get
            {
                return this.imieField;
            }
            set
            {
                this.imieField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort rokUr
        {
            get
            {
                return this.rokUrField;
            }
            set
            {
                this.rokUrField = value;
            }
        }
    }
}