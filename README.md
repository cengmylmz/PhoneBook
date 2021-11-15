### Telefon Rehberi 

* .NET 5.0
* ASPNET CORE MVC
* ASPNET CORE WEB API
* POSTGRESQL (Contact Data)
* RABBITMQ (Rapor Oluşturmak)
* MONGODB (Rapor Data)
* Ocelot (API Gateway)


Bilgisayarınızda hızlıca çalıştırmak için [docker](https://docs.docker.com/engine/install/) yüklemelisiniz.
Ardından komut satırı üzerinde aşağıdaki komutları çalıştırınız.

# Postgres için
`docker run --name phonebookpostgres -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=123456 -p 5432:5432 -d postgres`

# RabbitMQ için
`docker run -d  --name phonebookrabbitmq  -p 5672:5672 -p 15672:15672 rabbitmq:3-management`

# Mongodb için
`docker run --name phonebookmongodb -d -p 27017:27017 mongo`


Yukarıdaki komutları başarılı bir şekilde çalıştırdığınızda, <br/><br/>
**1.** Visual Studio üzerinde görseldeki gibi solution' a sağ tıklayıp açılan menüden **Set Startup Projects** ' i seçiniz.<br/>
<img src="https://i.ibb.co/vjKSBS8/s5.png" alt="s5" border="0"><br/>

**2.** Uygulamayı run ettiğinizde çalışacak projeleri aşağıda yer alan görseldeki gibi ayarlayınız.<br/>
<img src="https://i.ibb.co/WFB0sD4/s4.png" alt="s4" border="0">


Uygulamayı çalıştırdığınızda http://localhost:5010 adresinden erişim sağlayabileceksiniz.
Arayüze ait görseller aşağıda ki gibidir;

# Kişi Liste/Ekle/Sil

<img src="https://i.ibb.co/vZmFK5Q/s1.png" alt="s1" border="0">


# Kişi Bilgisi Liste/Ekle/Sil

<img src="https://i.ibb.co/QNygJ8B/s3.png" alt="s3" border="0">

# Rapor Liste/Ekle

<img src="https://i.ibb.co/9vfXdp6/s2.png" alt="s2" border="0">





