using System;


namespace DispensadorDeArena
{
    public static class Record
    {
        private static string _arenaType;
        private static  DateTime _dateTime; 
        private static  string _sandblastName; 
        private static  int _kilos;
        private static string Idbadge;
        

        public static void SetArenaType(string arena)
        {
            _arenaType = arena;
        }

        public static string GetArenaType()
        {
            return _arenaType;
        }

        //Agregar un switch case para meter los kilos correctos
        public static void SetKilos(string kilos)
        {

            _kilos = Convert.ToInt32(kilos);

        }

        public static int GetKilos()
        {
            return _kilos;
        }
        public static void SetTime(DateTime nowDateTime)
        {
            _dateTime = nowDateTime;
        }

        public static DateTime GetDateTime()
        {
            return _dateTime;
        }
        public static void SetBadge(string badge)
        {
            Idbadge = badge;
        }

        public static string GetBadge()
        {
            return Idbadge;

        }

        public static void SetSandblastName(string sandblast)
        {
            _sandblastName = sandblast;
        }

        public static string GetSandBlastName()
        {
            return _sandblastName;
        }


    }
}