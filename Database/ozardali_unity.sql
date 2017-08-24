-- phpMyAdmin SQL Dump
-- version 4.6.6
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 24 Ağu 2017, 23:59:03
-- Sunucu sürümü: 5.5.55-cll
-- PHP Sürümü: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `ozardali_unity`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `level`
--

CREATE TABLE `level` (
  `level_id` int(11) NOT NULL,
  `level_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `question`
--

CREATE TABLE `question` (
  `question_id` int(11) NOT NULL,
  `quest_category` int(11) NOT NULL,
  `quest_level` int(11) NOT NULL,
  `quest_name` text NOT NULL,
  `quest_answer1` text NOT NULL,
  `quest_answer2` text NOT NULL,
  `quest_answer3` text NOT NULL,
  `quest_answer4` text NOT NULL,
  `quest_answerTrue` char(2) NOT NULL,
  `quest_description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `question`
--

INSERT INTO `question` (`question_id`, `quest_category`, `quest_level`, `quest_name`, `quest_answer1`, `quest_answer2`, `quest_answer3`, `quest_answer4`, `quest_answerTrue`, `quest_description`) VALUES
(1, 1, 1, 'Hangi cümlede yazım yanlışı yapılmıştır', 'Benim evimde çiçek var.', 'Okula yürüyerek gidiyorum.', 'Süt içmeyi severim', 'Satranç oynamayı seviyorum.', '1', 'Atatürk \"Yurtta Barış, Dünyada Barış\" sözüyle Barışseverliğini göstermiştir.'),
(2, 1, 1, 'Hangisinde mi eki yanlış yazılmıştır?', 'Dersine çalıştın mı?', 'Bizimle mi oynayacaksın?', 'Ders mi çalışıyorsun?', 'Sendemi geleceksin?', '4', 'Laiklik, en temel anlamıyla din ve devlet işlerinin birbirinden ayrılması olarak tanımlanabilir.'),
(3, 1, 1, 'Aşağıdaki sözcüklerden hangisi eş seslidir?', 'Kalp', 'El', 'Yüz', '0', '3', 'İnkılapçılık, çağdaşlık ve yenilik demektir.'),
(4, 1, 1, 'Aşağıdaki tümcelerin hangisinde eş sesli cümle kullanımı yapılmıştır?', 'Derslerine çok daha iyi çalış', 'Bizim evimiz buraya daha yakın', 'Arabanın arkasına bindi', '0', '3', 'Atatürk dünya barışından, bilimden ve akıldan yanadır.'),
(5, 1, 1, 'Aşağıdaki cümlelerin hanginin sonuna noktalama işareti koyulmalıdır?', 'Gözlerini çok beğendim', 'Nereye gidiyorsun', 'Eyvah parmağım kesildi\r\n', '0', '1', 'Medreseler, cumhuriyet öncesi eğitim veren okullardır.'),
(6, 1, 1, 'Aşağıdaki bilgilerden hangisi yanlıştır?', 'Cümlelerin ilk harfi büyük yazılır', 'Cümlelerde gereksiz kelime kullanabilirsiniz', 'Her cümlenin sonuna nokta konulmaz', '0', '2', 'Medeni Kanun ile kadın erkek eşitliği sağlanmıştır.'),
(7, 1, 1, 'Yüzümüzü güneşin doğdugu yere döndüğümüzde sağ kolumuz hangi yönü gösterir?', 'Kuzey', 'Güney', 'Batı', '0', '2', 'Takvim, saat gibi ölçülerin değiştirilmesi Toplumsal alandaki inkılaplardandır.'),
(8, 1, 1, 'Atatürk hangi tarihte doğmuştur?', '1923', '1881', '1938', '0', '2', 'Ulu Önder Gazi Mustafa Kemal Atatürk Selanik\'te 1881 yılında doğmuştur.'),
(11, 1, 1, 'Kurtuluş Savaşı Ne zaman Başlamıştır?', '1900', '1910', '1919', '0', '3', 'Kurtuluş Savaşı Atatürk\'ün Samsun\'a çıkmasıyla 19 Mayıs 1919\'da başlamıştır.'),
(12, 1, 1, 'Kurtuluş Savaşı Ne zaman Başlamıştır?', '1900', '1910', '1919', '0', '3', '-Egemenlik, kayıtsız şartsız milletindir. sözü Milliyetçilik ile ilgilidir.'),
(13, 1, 1, 'Kurtuluş Savaşı Ne zaman Başlamıştır?', '1900', '1910', '1919', '0', '3', 'Türk Medeni Kanunu\'nun çıkarılması bir inkılap değildir.');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `questioncategory`
--

CREATE TABLE `questioncategory` (
  `cat_id` int(11) NOT NULL,
  `cat_name` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Tablo döküm verisi `questioncategory`
--

INSERT INTO `questioncategory` (`cat_id`, `cat_name`) VALUES
(1, 'Türkçe'),
(2, 'Matematik'),
(3, 'Sosyal Bilgiler'),
(4, 'Genel Kültür');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `scoreboard`
--

CREATE TABLE `scoreboard` (
  `board_id` int(11) NOT NULL,
  `board_user` int(11) NOT NULL,
  `board_level` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `users`
--

CREATE TABLE `users` (
  `u_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `level`
--
ALTER TABLE `level`
  ADD PRIMARY KEY (`level_id`);

--
-- Tablo için indeksler `question`
--
ALTER TABLE `question`
  ADD PRIMARY KEY (`question_id`);

--
-- Tablo için indeksler `questioncategory`
--
ALTER TABLE `questioncategory`
  ADD PRIMARY KEY (`cat_id`);

--
-- Tablo için indeksler `scoreboard`
--
ALTER TABLE `scoreboard`
  ADD PRIMARY KEY (`board_id`);

--
-- Tablo için indeksler `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`u_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `level`
--
ALTER TABLE `level`
  MODIFY `level_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `question`
--
ALTER TABLE `question`
  MODIFY `question_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- Tablo için AUTO_INCREMENT değeri `questioncategory`
--
ALTER TABLE `questioncategory`
  MODIFY `cat_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- Tablo için AUTO_INCREMENT değeri `scoreboard`
--
ALTER TABLE `scoreboard`
  MODIFY `board_id` int(11) NOT NULL AUTO_INCREMENT;
--
-- Tablo için AUTO_INCREMENT değeri `users`
--
ALTER TABLE `users`
  MODIFY `u_id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
