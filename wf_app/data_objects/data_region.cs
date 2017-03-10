
//=============================================================================
// data_region - данные записи таблицы region РАЙОН(ЗОНА) ПРОМЫСЛА
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         10-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;

namespace cfmc.quotas.db_objects
{

    public class data_region
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public data_region()
        {

            this.initialize();
        }
        #endregion //__CONSTRUCTION__	

        /*
         * --------------------------------------------------------------------
         *                          PROPERTIES
         * --------------------------------------------------------------------
         */
        #region __PROPERTIES__
        /// <summary>
        /// id_region
        /// поле запроса - id_region
        /// Идентификатор района промысла
        /// </summary>
        public int id_region { get; set; }
        /// <summary>
        /// region
        /// поле запроса - region
        /// Район промысла
        /// </summary>
        public string region { get; set; }
        /// <summary>
        /// note
        /// поле запроса - note
        /// Примечание
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// region_order
        /// поле запроса - region_order
        /// Наименование согласно утверждённому приказу
        /// </summary>
        public string region_order { get; set; }
        /// <summary>
        /// id_region_osm
        /// поле запроса - id_region_osm
        /// Код в ОСМ
        /// </summary>
        public int id_region_osm { get; set; }
        /// <summary>
        /// sorting
        /// поле запроса - sorting
        /// Порядок сортировки
        /// </summary>
        public int sorting { get; set; }
        #endregion//__PROPERTIES__

        /*
         * --------------------------------------------------------------------
         *                          INITIALIZE
         * --------------------------------------------------------------------
         */
        #region __INITIALIZE__
        void initialize()
        {
        }
        #endregion //__INITIALIZE__

        /*
        * --------------------------------------------------------------------
        *                          METHODS
        * --------------------------------------------------------------------
        */
        #region __METHODS__
        #endregion//__METHODS__

        /*
         * --------------------------------------------------------------------
         *                          EVENTS
         * --------------------------------------------------------------------
         */
        #region __EVENTS__
        #endregion//__EVENTS__

        /*
         * --------------------------------------------------------------------
         *                          FIELDS
         * --------------------------------------------------------------------
         */
        #region __FIELDS__
        #endregion//__FIELDS__

    }//class data_region

}//namespace cfmc.quotas.db_objects

            