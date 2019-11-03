-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 01 Ara 2018, 23:12:23
-- Sunucu sürümü: 10.1.34-MariaDB
-- PHP Sürümü: 7.2.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `emre_test`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kategoriler`
--

CREATE TABLE `kategoriler` (
  `kategori_id` int(11) NOT NULL,
  `ad` varchar(60) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Tablo döküm verisi `kategoriler`
--

INSERT INTO `kategoriler` (`kategori_id`, `ad`) VALUES
(1, 'Genel Kultur'),
(2, 'Temel Bilgisayar'),
(3, 'Matemetik'),
(4, 'Yazılım'),
(5, 'Psikoloji');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ogr_bilgi`
--

CREATE TABLE `ogr_bilgi` (
  `ogr_id` int(11) NOT NULL,
  `ad_soyad` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `tc` int(11) NOT NULL,
  `sinif` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `d_tarihi` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `k_tarihi` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `telefon` varchar(15) COLLATE utf8_turkish_ci NOT NULL,
  `k1` int(11) NOT NULL,
  `k2` int(11) NOT NULL,
  `k3` int(11) NOT NULL,
  `k4` int(11) NOT NULL,
  `k5` int(11) NOT NULL,
  `puan` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `ogr_bilgi`
--

INSERT INTO `ogr_bilgi` (`ogr_id`, `ad_soyad`, `tc`, `sinif`, `d_tarihi`, `k_tarihi`, `telefon`, `k1`, `k2`, `k3`, `k4`, `k5`, `puan`) VALUES
(5, 'murat', 112, '2', '', '', 'cs51', 20, 20, 20, 0, 20, 80),
(6, 'emre', 1, '', '1.12.2018 02:17:25', '1.12.2018 02:17:25', '', 0, 0, 0, 0, 0, 0),
(7, 'suna', 123, '', '', '', '', 0, 0, 0, 0, 0, 0),
(8, 'merve', 6363, '', '1.12.2018 02:17:39', '1.12.2018 02:17:39', '', 0, 0, 0, 0, 0, 0),
(9, 'ali', 27, '', '', '', '', 0, 0, 0, 0, 0, 0),
(10, 'merve', 63631, '', '1.12.2018 02:17:39', '1.12.2018 02:17:39', '', 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `sorular`
--

CREATE TABLE `sorular` (
  `soru_id` int(11) NOT NULL,
  `soru` text COLLATE utf8_turkish_ci NOT NULL,
  `a` text COLLATE utf8_turkish_ci NOT NULL,
  `b` text COLLATE utf8_turkish_ci NOT NULL,
  `c` text COLLATE utf8_turkish_ci NOT NULL,
  `d` text COLLATE utf8_turkish_ci NOT NULL,
  `dogru` text COLLATE utf8_turkish_ci NOT NULL,
  `kat_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `sorular`
--

INSERT INTO `sorular` (`soru_id`, `soru`, `a`, `b`, `c`, `d`, `dogru`, `kat_id`) VALUES
(1, 'tuekiyenin başkenti neresidir?', 'istanbul', 'ankara', 'bursa', 'gaziantep', 'ankara', 1),
(2, '2+2', '4', '5', '6', '10', '4', 3),
(3, 'rem nedir', 'gecici bellek', 'kalıcı bellek', 'tarayıcıdr', 'bi bok değildir', 'gecici bellek', 2),
(4, 'if nedir', 'koşuldur', 'döngüdür', 'sql bağlantısıdır', 'bi bok değildir', 'koşuldur', 4),
(6, 'heloo', 'd', 'z', 'd', 'v', 'v', 5),
(7, 'beni seviyon mu', 'evet', 'hayir', 'bazen', 'herzamn', 'evet', 1),
(8, 'cdsc', 'cs', 'csd', 'cdscds', 'd', 'd', 4),
(9, 'sdsd', 'd', 's', 'c', 's', 's', 2),
(10, '', '', '', '', '', '', 1),
(11, '', '', '', '', '', '', 1),
(12, 'vsdv', 'ffcsdv', 'saasas', 'sa', 'sa', 'sa', 1),
(13, 'kknlnkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk', '', '', '', '', '', 1),
(14, '', '', '', '', '', '', 1),
(15, '', '', '', '', '', '', 1),
(16, '', '', '', '', '', '', 1),
(17, '', '', '', '', 'SS', '', 1);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `kategoriler`
--
ALTER TABLE `kategoriler`
  ADD PRIMARY KEY (`kategori_id`);

--
-- Tablo için indeksler `ogr_bilgi`
--
ALTER TABLE `ogr_bilgi`
  ADD PRIMARY KEY (`ogr_id`);

--
-- Tablo için indeksler `sorular`
--
ALTER TABLE `sorular`
  ADD PRIMARY KEY (`soru_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `kategoriler`
--
ALTER TABLE `kategoriler`
  MODIFY `kategori_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `ogr_bilgi`
--
ALTER TABLE `ogr_bilgi`
  MODIFY `ogr_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Tablo için AUTO_INCREMENT değeri `sorular`
--
ALTER TABLE `sorular`
  MODIFY `soru_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
