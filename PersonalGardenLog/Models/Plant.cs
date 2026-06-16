using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalGardenLog.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "植物の名前を入力してください")]
        public string Name { get; set; } = string.Empty;

        public string? Species { get; set; } // 品種（任意）

        [Required]
        [Range(1, 365, ErrorMessage = "水やり間隔は1日以上に設定してください")]
        public int WateringIntervalDays { get; set; } // 水やりが必要な周期（日数）

        public DateTime LastWateredDate { get; set; } = DateTime.Now; // 最後に水やりした日

        // 次回水やり予定日を自動計算するプロパティ（ロジック）
        public DateTime NextWateringDate => LastWateredDate.AddDays(WateringIntervalDays);

        // 水やりが必要な状態かどうかを判定するフラグ
        public bool IsUrgent => DateTime.Now.Date >= NextWateringDate.Date;
    }
}