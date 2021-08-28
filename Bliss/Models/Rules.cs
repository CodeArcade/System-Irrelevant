using System;
using System.Collections.Generic;
using System.Text;
using Bliss.Component.Sprites.Office.Documents;

namespace Bliss.Models
{
    public static class Rules
    {
        #region BettyRules

        #region BinRules

        public static Rule NoMaleApplicants
        {
            get
            {
                return new Rule(DocumentType.Application)
                {
                    Validate = (document) =>
                    {
                        if (document is Application application)
                        {
                            return application.Sex != Sexes.Male;
                        }

                        return false;
                    },
                    Description = "Only applications sent by women",
                };
            }
        }

        public static Rule MaleApplicants
        {
            get
            {
                return new Rule(DocumentType.Application)
                {
                    Validate = (document) =>
                    {
                        if (document is Application application)
                        {
                            return application.Sex == Sexes.Male;
                        }

                        return false;
                    },
                    Description = "Toss all applications sent by men",
                };
            }
        }

        public static Rule InvalidDepartments
        {
            get
            {
                return new Rule(DocumentType.Paycheck)
                {
                    Validate = (document) =>
                    {
                        if (document is Paycheck check)
                        {
                            return (int)check.Department >= 5;
                        }

                        return false;
                    },
                    Description = "Toss paychecks if not adressed to valid departments:" + Environment.NewLine + "Human Resources, Public Relations, Research and Development, IT, Accounting"
                };
            }
        }

        public static Rule ValidDepartments
        {
            get
            {
                return new Rule(DocumentType.Paycheck)
                {
                    Validate = (document) =>
                    {
                        if (document is Paycheck check)
                        {
                            return (int)check.Department < 5;
                        }

                        return false;
                    },
                    Description = "Toss paychecks not adressed to one of these departments:\n"
                        + "Human Resources, Public Relations, Research and Development, IT, Accounting"
                };
            }
        }

        public static Rule InvalidLetter
        {
            get
            {
                return new Rule(DocumentType.Letter)
                {
                    Validate = (document) =>
                    {
                        if (document is Letter letter)
                        {
                            return !letter.HasStamp && string.IsNullOrEmpty(letter.ReturnAddress);
                        }

                        return false;
                    },
                    Description = "Toss letters without stamp and return address"
                };
            }
        }

        public static Rule ValidLetter
        {
            get
            {
                return new Rule(DocumentType.Letter)
                {
                    Validate = (document) =>
                    {
                        if (document is Letter letter)
                        {
                            return letter.HasStamp && !string.IsNullOrEmpty(letter.ReturnAddress);
                        }

                        return false;
                    },
                    Description = "Toss letters without stamp and return address"
                };
            }
        }

        #endregion

        #endregion

        #region Mike Rules

        #region Bin Rules 

        /// <summary>
        /// bin rule
        /// </summary>
        public static Rule UnsignedContracts
        {
            get
            {
                return new Rule(DocumentType.Contract)
                {
                    Validate = (document) =>
                    {
                        if (document is Contract contract)
                        {
                            return !contract.HasSignature;
                        }
                        return false;
                    },
                    Description = "Toss without signature"
                };
            }
        }

        #endregion

        #endregion

        #region Boss Rules

        #region Bin Rules

        /// <summary>
        /// bin rule
        /// </summary>
        public static Rule HardcoreRacism
        {
            get
            {
                return new Rule(DocumentType.Application)
                {
                    Validate = (document) =>
                    {
                        if (document is Application application)
                        {
                            return application.Country != Countries.America;
                        }
                        return false;
                    },
                    Description = "Toss from non-american applicants"
                };
            }
        }

        /// <summary>
        /// bin rule
        /// </summary>
        public static Rule LightcoreRacism
        {
            get
            {
                return new Rule(DocumentType.Application)
                {
                    Validate = (document) =>
                    {
                        if (document is Application application)
                        {
                            switch (application.Country)
                            {
                                case Countries.Denmark:
                                case Countries.Sweden:
                                case Countries.Norway:
                                case Countries.Finland:
                                case Countries.UnitedKingdom:
                                    return true;
                            }
                        }
                        return false;
                    },
                    Description = "Toss applications from northern countries"
                };
            }
        }

        #endregion

        #region Blue Rules

        public static Rule SignedContracts
        {
            get
            {
                return new Rule(DocumentType.Contract)
                {
                    Validate = (document) =>
                    {
                        if (document is Contract contract)
                        {
                            return contract.HasSignature;
                        }
                        return false;
                    },
                    Description = "Toss contracts without valid signature"
                };
            }
        }

        #endregion

        #region Red Rules

        public static Rule AmericanApplicants
        {
            get
            {
                return new Rule(DocumentType.Application)
                {
                    Validate = (document) =>
                    {
                        if (document is Application application)
                        {
                            return application.Country == Countries.America;
                        }
                        return false;
                    },
                    Description = "Toss applications not from americans."
                };
            }
        }

        public static Rule FuckNorthernEurope
        {
            get
            {
                return new Rule(DocumentType.Application)
                {
                    Validate = (document) =>
                    {
                        if (document is Application application)
                        {
                            switch (application.Country)
                            {
                                case Countries.Denmark:
                                case Countries.Sweden:
                                case Countries.Norway:
                                case Countries.Finland:
                                case Countries.UnitedKingdom:
                                    return false;
                            }
                            return true;
                        }
                        return false;
                    },
                    Description = "Toss applicationsn from northern countries"
                };
            }
        }

        #endregion

        #endregion

        #region General Document Rules

        public static Rule IsPaycheckForBlue
        {
            get
            {
                return new Rule(DocumentType.Paycheck)
                {
                    Description = "Put in blue organizer",
                    Validate = document => document is Paycheck
                };
            }
        }

        public static Rule IsPaycheckForRed
        {
            get
            {
                return new Rule(DocumentType.Paycheck)
                {
                    Description = "Put in red organizer",
                    Validate = document => document is Paycheck
                };
            }
        }

        public static Rule IsContract
        {
            get
            {
                return new Rule(DocumentType.Contract)
                {
                    Description = "Put in blue organizer",
                    Validate = document => document is Contract
                };
            }
        }

        public static Rule IsApplicationForRed
        {
            get
            {
                return new Rule(DocumentType.Application)
                {
                    Description = "Put in red organizer",
                    Validate = document => document is Application
                };
            }
        }

        public static Rule IsClassified
        {
            get
            {
                return new Rule(DocumentType.Classified)
                {
                    Description = "Toss in trash",
                    Validate = document => document is Classified
                };
            }
        }

        public static Rule IsLetter
        {
            get
            {
                return new Rule(DocumentType.Letter)
                {
                    Description = "Put in green organizer",
                    Validate = document => document is Letter
                };
            }
        }

        #endregion
    }
}