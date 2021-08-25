using System;
using System.Collections.Generic;
using System.Text;
using Bliss.Component.Sprites.Office.Documents;

namespace Bliss.Models
{
    public static class Rules
    {
        /// <summary>
        /// bin rule
        /// </summary>
        public static Rule NoMaleApplicants
        {
            get
            {
                return new Rule()
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

        /// <summary>
        /// bin rule
        /// </summary>
        public static Rule Classified
        {
            get
            {
                return new Rule()
                {
                    Validate = (document) =>
                    {
                        return document is Classified;
                    },
                    Description = "Toss all classified documents",
                };
            }
        }

        /// <summary>
        /// bin rule
        /// </summary>
        public static Rule HardcoreRacism
        {
            get
            {
                return new Rule()
                {
                    Validate = (document) =>
                    {
                        if (document is Application application)
                        {
                            return application.Location == Locations.America;
                        }
                        return false;
                    },
                    Description = "Toss applications from non-american applicants"
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
                return new Rule()
                {
                    Validate = (document) =>
                    {
                        if (document is Application application)
                        {
                            switch (application.Location)
                            {
                                case Locations.Denmark:
                                case Locations.Sweden:
                                case Locations.Norway:
                                case Locations.Finland:
                                case Locations.UnitedKingdom:
                                    return true;
                            }
                        }
                        return false;
                    },
                    Description = "Toss applications from Denmark, Sweden, Norway, Finland and UK"
                };
            }
        }

        /// <summary>
        /// bin rule
        /// </summary>
        public static Rule UnsignedContracts
        {
            get
            {
                return new Rule()
                {
                    Validate = (document) =>
                    {
                        if (document is Contract contract)
                        {
                            return !contract.HasSignature;
                        }
                        return false;
                    },
                    Description = "Toss contracts without signature."
                };
            }
        }

        /// <summary>
        /// bin rule
        /// </summary>
        public static Rule InvalidDepartments
        {
            get
            {
                return new Rule()
                {
                    Validate = (document) =>
                    {
                        if (document is Paycheck check)
                        {
                            return (int)check.Department >= 5;
                        }

                        return false;
                    },
                    Description = "Toss the paycheck if its not adressed to one of these departments:\n"
                        + "Human Resources, Public Relations, Research and Development, IT, Accounting"
                };
            }
        }

        public static Rule InvalidLetter
        {
            get
            {
                return new Rule()
                {
                    Validate = (document) =>
                    {
                        if (document is Letter letter)
                        {
                            return !letter.HasStamp && string.IsNullOrEmpty(letter.ReturnAdress);
                        }

                        return false;
                    },
                    Description = "Toss letters if they don't have a stamp and a return address."
                };
            }
        }
    }
}
