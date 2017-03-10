
//=============================================================================
// data_WBR - данные записи таблицы fish ВБР
// Автор: Иванченко М.В.
// Дата начала разработки:  10-03-2017
// Дата обновления:         10-03-2017
// Первый релиз:            0.0.0.0
// Текущий релиз:           0.0.0.0
//=============================================================================
using System;

namespace cfmc.quotas.db_objects
{

    public class data_WBR
    {
        /*
         * --------------------------------------------------------------------
         *                          CONSTRUCTION
         * --------------------------------------------------------------------
         */
        #region __CONSTRUCTION__	
        public data_WBR()
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
        /// id_fish
        /// поле запроса - id_fish
        /// Идентификатор ВБР
        /// </summary>
        public int id_fish { get; set; }
        /// <summary>
        /// fish
        /// поле запроса - fish
        /// ВБР
        /// </summary>
        public string fish { get; set; }
        /// <summary>
        /// note
        /// поле запроса - note
        /// Примечание
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// fish_order
        /// поле запроса - fish_order
        /// Наименование согласно утверждённому приказу
        /// </summary>
        public string fish_order { get; set; }
        /// <summary>
        /// id_fish_osm
        /// поле запроса - id_fish_osm
        /// Код в ОСМ
        /// </summary>
        public int id_fish_osm { get; set; }
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

    }//class data_WBR

}//namespace cfmc.quotas.db_objects

            