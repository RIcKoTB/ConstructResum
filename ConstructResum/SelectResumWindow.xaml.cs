    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace ConstructResum
{
    public partial class SelectResumWindow : Window
    {
        private const string pathToData = @"Data\\";

        private string name;
        private string surname;
        private string email;
        private string phone;
        private string sex;
        private string data;
        private string photo;
        private string posada;
        private string city;
        private string opis;
        private string studylvl;
        private string navchalka;
        private string facult;
        private string about;

        public SelectResumWindow(string name, string surname, string email, string phone, string sex, 
            string data, string photo, string posada, string city, string opis, string studylvl, string navchalka, 
            string facult, string about)
        {
            InitializeComponent();

            this.name = name;
            this.surname = surname;
            this.email = email;
            this.phone = phone;
            this.sex = sex;
            this.data = data;
            this.photo = photo;
            this.posada = posada;
            this.city = city;
            this.opis = opis;
            this.studylvl = studylvl;
            this.navchalka = navchalka;
            this.facult = facult;
            this.about = about;
        }

        private void btnStep_Click(object sender, RoutedEventArgs e)
        {
            SecondInfoWindow secondInfoWindow = new SecondInfoWindow(name, surname, email, phone, sex, data, photo);
            secondInfoWindow.Show();
            this.Close();
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow();
            signInWindow.Show();
            this.Close();
        }

        private void btnStyle1_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(pathToData + "\\html"))
            {
                Directory.CreateDirectory(pathToData + "\\html");
            }

            string html = $@"
               <!DOCTYPE html>
                        <html lang=""en"">
                            <head>
                                <meta charset=""utf-8"" />
                                <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"" />
                                <meta name=""description"" content="""" />
                                <meta name=""author"" content="""" />
                                <title>Ваше резюме</title>
                                <link rel=""icon"" type=""image/x-icon"" href=""assets/img/favicon.ico"" />
                                <!-- Font Awesome icons (free version)-->
                                <script src=""https://use.fontawesome.com/releases/v6.1.0/js/all.js"" crossorigin=""anonymous""></script>
                                <!-- Google fonts-->
                                <link href=""https://fonts.googleapis.com/css?family=Saira+Extra+Condensed:500,700"" rel=""stylesheet"" type=""text/css"" />
                                <link href=""https://fonts.googleapis.com/css?family=Muli:400,400i,800,800i"" rel=""stylesheet"" type=""text/css"" />
                                <!-- Core theme CSS (includes Bootstrap)-->
                                <link href=""css/styles.css"" rel=""stylesheet"" />
                            </head>
    
                            <body id=""page-top"">
                                <!-- Navigation-->
                                <nav class=""navbar navbar-expand-lg navbar-dark bg-primary fixed-top"" id=""sideNav"">
                                    <a class=""navbar-brand js-scroll-trigger"" href=""#page-top"">
                                        <span class=""d-block d-lg-none"">Vladislav</span>
                                        <span class=""d-none d-lg-block""><img class=""img-fluid img-profile rounded-circle mx-auto mb-2"" src=""{photo}"" alt=""..."" /></span>
                                    </a>
                                    <button class=""navbar-toggler"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#navbarResponsive"" aria-controls=""navbarResponsive"" aria-expanded=""false"" aria-label=""Toggle navigation""><span class=""navbar-toggler-icon""></span></button>
                                    <div class=""collapse navbar-collapse"" id=""navbarResponsive"">
                                        <ul class=""navbar-nav"">
                                            <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#about"">Про мене</a></li>
                                            <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#experience"">Досвід роботи</a></li>
                                            <li class=""nav-item""><a class=""nav-link js-scroll-trigger"" href=""#education"">Освіта</a></li>
                                        </ul>
                                    </div>
                                </nav>
                                <!-- Page Content-->
                                <div class=""container-fluid p-0"">
                                    <!-- About-->
                                    <section class=""resume-section"" id=""about"">
                                        <div class=""resume-section-content"">
                                            <h1 class=""mb-0"">
                                                {name + " " + surname}
                                            </h1>
                                            <div class=""subheading mb-5"">
                                                {phone} <br>
                                                <a>{email}</a>
                                                <h5>Дата народження: {data}</h5>
                                                <h6>Стать: {sex}</h6>
                                            </div>
                                            <p class=""lead mb-5"">{about}</p>
                                        </div>
                                    </section>
                                    <hr class=""m-0"" />
                                    <!-- Experience-->
                                    <section class=""resume-section"" id=""experience"">
                                        <div class=""resume-section-content"">
                                            <h2 class=""mb-5"">Досвід роботи</h2>
                                            <div class=""d-flex flex-column flex-md-row justify-content-between mb-5"">
                                                <div class=""flex-grow-1"">
                                                    <h3 class=""mb-0"">{posada}</h3>
                                                    <div class=""subheading mb-3"">{city}</div>
                                                    <p>{opis}</p>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                    <hr class=""m-0"" />
                                    <!-- Education-->
                                    <section class=""resume-section"" id=""education"">
                                        <div class=""resume-section-content"">
                                            <h2 class=""mb-5"">Освіта</h2>
                                            <div class=""d-flex flex-column flex-md-row justify-content-between mb-5"">
                                                <div class=""flex-grow-1"">
                                                    <h3 class=""mb-0"">Навчальний заклад</h3>
                                                    <div class=""subheading mb-3"">{navchalka}</div>
                                                    <div>Факультет, спеціальність</div>
                                                    <p>{facult}</p>
                                                    <div>Рівень овсвіти</div>
                                                    <p>{studylvl}</p>
                                                </div>
                                            </div>
                                        </div>
                                    </section>
                                </div>
                                <!-- Bootstrap core JS-->
                                <script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js""></script>
                                <!-- Core theme JS-->
                                <script src=""js/scripts.js""></script>
                            </body>
                        </html>
                    ";

            File.WriteAllText(pathToData + "html\\" + "style1\\" + "index.html", html);

            Process.Start(new ProcessStartInfo(pathToData + "html\\" + "style1\\" + "index.html") { UseShellExecute = true });
        }

        private void btnStyle2_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(pathToData + "\\html"))
            {
                Directory.CreateDirectory(pathToData + "\\html");
            }

            string html = $@"
              <!doctype html>
                <html lang=""en"">

                <head>
                    <meta charset=""utf-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">
                    <title>Ваше резюме</title>

                    <link rel=""shortcut icon"" href=""assets/images/fav.jpg"">
                    <link rel=""stylesheet"" href=""assets/css/bootstrap.min.css"">
                    <link rel=""stylesheet"" href=""assets/css/fontawsom-all.min.css"">
                    <link rel=""stylesheet"" type=""text/css"" href=""assets/css/style.css"" />
                </head>

                <body>
                    <div class=""container-fluid overcover"">
                        <div class=""container profile-box"">
                            <div class=""row"">
                                <div class=""col-md-4 left-co"">
                                    <div class=""left-side"">
                                        <div class=""profile-info"">
                                            <img src=""{photo}"" alt="""">
                                            <h3>{name + " " + surname}</h3>
                                        </div>
                                        <h4 class=""ltitle"">Контакти</h4>
                                        <div class=""contact-box pb0"">
                                            <div class=""icon"">
                                                <i class=""fas fa-phone""></i>
                                            </div>
                                            <div class=""detail"">
                                                {phone} 
                                            </div>
                                        </div>
                                        <div class=""contact-box pb0"">
                                            <div class=""icon"">
                                                <i class=""fas fa-globe-americas""></i>
                                            </div>
                                            <div class=""detail"">
                                                {email}
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class=""col-md-8 rt-div"">
                                    <div class=""rit-cover"">
                                        <div class=""hotkey"">
                                            <h1 class="""">{name + " " + surname}</h1>
                                        </div>
                                        <h2 class=""rit-titl""><i class=""far fa-user""></i>Про мене</h2>
                                        <div class=""about"">
                                            <p>Дата народження: {data}</p>
                                            <p>Стать: {sex}</p>
                                            <p>{about}</p>
                                        </div>

                                        <h2 class=""rit-titl""><i class=""fas fa-briefcase""></i>Досвід роботи</h2>
                                        <div class=""work-exp"">
                                            <h6>{city}</h6>
                                            <i>{posada}</i>
                                            <p>{opis}</p>
                                        </div>

                                        <h2 class=""rit-titl""><i class=""fas fa-graduation-cap""></i>Освіта</h2>
                                        <div class=""education"">
                                            <ul class=""row no-margin"">
                                                <li class=""col-md-6"">
                                                    {navchalka} <br>
                                                    {facult} <br>
                                                    {studylvl}</li>
                                            </ul>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </body>

                <script src=""assets/js/jquery-3.2.1.min.js""></script>
                <script src=""assets/js/popper.min.js""></script>
                <script src=""assets/js/bootstrap.min.js""></script>
                <script src=""assets/js/script.js""></script>

                </html>
                    ";

            File.WriteAllText(pathToData + "html\\" + "style2\\" + "index.html", html);

            Process.Start(new ProcessStartInfo(pathToData + "html\\" + "style2\\" + "index.html") { UseShellExecute = true });
        }

        private void btnStyle3_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(pathToData + "\\html"))
            {
                Directory.CreateDirectory(pathToData + "\\html");
            }

            string html = $@"
              <!DOCTYPE html>
                <html>
                <head>
                    <title>Draco by @afnizarnur</title>
                    <meta charset=""utf-8"" />
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                    <meta name=""description"" content=""Draco is free PSD &amp; HTML template by @afnizarnur"">
                    <meta name=""author"" content="""">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
                    <link rel=""stylesheet"" href=""css/kube.min.css"" />
                    <link rel=""stylesheet"" href=""css/font-awesome.min.css"" />
                    <link rel=""stylesheet"" href=""css/custom.min.css"" />
                    <link rel=""shortcut icon"" href=""img/favicon.png"" />
	                <link href='http://fonts.googleapis.com/css?family=Playfair+Display+SC:700' rel='stylesheet' type='text/css'>
	                <link href='http://fonts.googleapis.com/css?family=Lato:400,700' rel='stylesheet' type='text/css'>
	                <style>
		                .intro h1:before {{
			                /* Edit this with your name or anything else */
			                content: 'DRACO';
		                }}
	                </style>
                </head>
                <body>
	                <!-- Navigation -->
	                <div class=""main-nav"">
		                <div class=""container"">
			                <header class=""group top-nav"">
				                <div class=""navigation-toggle"" data-tools=""navigation-toggle"" data-target=""#navbar-1"">
				                </div>
			                    <nav id=""navbar-1"" class=""navbar item-nav"">
				                    <ul>
				                        <li class=""active""><a href=""#about"">Про мене</a></li>
				                        <li><a href=""#experiences"">Досвід роботи</a></li>
				                        <li><a href=""#achievements"">Освіта</a></li>
				                    </ul>
				                </nav>
			                </header>
		                </div>
	                </div>

	                <!-- Introduction -->
	                <div class=""intro section"" id=""about"">
		                <div class=""container"">
			                <p>Привіт, я {name + " " + surname}</p>
			                <div class=""units-row units-split wrap"">
				                <div class=""unit-20"">
					                <img src=""{photo}"" alt=""Avatar"">
				                </div>
				                <div class=""unit-80"">
					                <h1>Мої дані<br><span>{email} <br> {phone}</span></h1>
				                </div>
				                <p>Дата народження: {data}</p>
				                <p>Стать: {sex}</p>
				                <p>{about}</p>
			                </div>
		                </div>
	                </div>

	                <!-- Work Experience -->
	                <div class=""work section second"" id=""experiences"">
		                <div class=""container"">
			                <h1>Досвід роботи</h1>
			                <ul class=""work-list"">
				                <li><a href=""#"">{posada}</a></li>
				                <li>{city}</li>
				                <li>{opis}</li>
			                </ul>
		                </div>
	                </div>

	                <!-- Award & Achievements -->
	                <div class=""award section second"" id=""achievements"">
		                <div class=""container"">
			                <h1>Освіта</h1>
			                <ul class=""award-list list-flat"">
				                <li>{navchalka}</li>
				                <li>{facult}</li>
				                <li>{studylvl}</li>
			                </ul>
		                </div>
	                </div>
	                <!-- Javascript -->
	                <script src=""js/jquery.min.js""></script>
	                <script src=""js/typed.min.js""></script>
                    <script src=""js/kube.min.js""></script>
                    <script src=""js/site.js""></script>
                    <script>
		                function newTyped(){{}}$(function(){{$(""#typed"").typed({{
		                // Change to edit type effect
		                strings: [""far northern sky"", ""your galaxy"", ""everywhere""],

		                typeSpeed:90,backDelay:700,contentType:""html"",loop:!0,resetCallback:function(){{newTyped()}}}}),$("".reset"").click(function(){{$(""#typed"").typed(""reset"")}})}});
                    </script>
                </body>
                </html>

                    ";

            File.WriteAllText(pathToData + "html\\" + "style3\\" + "index.html", html);

            Process.Start(new ProcessStartInfo(pathToData + "html\\" + "style3\\" + "index.html") { UseShellExecute = true });
        }

        private void btnStyle4_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(pathToData + "\\html"))
            {
                Directory.CreateDirectory(pathToData + "\\html");
            }

            string html = $@"
              <!DOCTYPE html>
                <html lang=""en-US"">
                  <head>
                    <meta charset=""UTF-8"">
                    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
                    <title>Creative CV</title>
                    <link href=""https://fonts.googleapis.com/css?family=Montserrat:400,700,200"" rel=""stylesheet"">
                    <link href=""https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css"" rel=""stylesheet"">
                    <link href=""css/aos.css?ver=1.1.0"" rel=""stylesheet"">
                    <link href=""css/bootstrap.min.css?ver=1.1.0"" rel=""stylesheet"">
                    <link href=""css/main.css?ver=1.1.0"" rel=""stylesheet"">
                    <noscript>
                      <style type=""text/css"">
                        [data-aos] {{
                            opacity: 1 !important;
                            transform: translate(0) scale(1) !important;
                        }}
                      </style>
                    </noscript>
                  </head>
                  <body id=""top"">
                    <header>
                      <div class=""profile-page sidebar-collapse"">
                        <nav class=""navbar navbar-expand-lg fixed-top navbar-transparent bg-primary"" color-on-scroll=""400"">
                          <div class=""container"">
                            <div class=""navbar-translate""><a class=""navbar-brand"" href=""#"" rel=""tooltip"">Твоє резюме</a>
                              <button class=""navbar-toggler navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navigation"" aria-controls=""navigation"" aria-expanded=""false"" aria-label=""Toggle navigation""><span class=""navbar-toggler-bar bar1""></span><span class=""navbar-toggler-bar bar2""></span><span class=""navbar-toggler-bar bar3""></span></button>
                            </div>
                            <div class=""collapse navbar-collapse justify-content-end"" id=""navigation"">
                              <ul class=""navbar-nav"">
                                <li class=""nav-item""><a class=""nav-link smooth-scroll"" href=""#about"">Про мене</a></li>
                                <li class=""nav-item""><a class=""nav-link smooth-scroll"" href=""#Education"">Освіта</a></li>
                                <li class=""nav-item""><a class=""nav-link smooth-scroll"" href=""#experience"">Досвід роботи</a></li>
                              </ul>
                            </div>
                          </div>
                        </nav>
                      </div>
                    </header>
                    <div class=""page-content"">
                      <div>
                <div class=""profile-page"">
                  <div class=""wrapper"">
                    <div class=""page-header page-header-small"" filter-color=""green"">
                      <div class=""page-header-image"" data-parallax=""true"" style=""background-image: url('images/cc-bg-1.jpg')""></div>
                      <div class=""container"">
                        <div class=""content-center"">
                          <div class=""cc-profile-image""><a href=""#""><img src=""{photo}"" alt=""Image""/></a></div>
                          <div class=""h2 title"">{name + " " + surname}</div>
                          <p class=""category text-white"">{email + " " + phone}</p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div class=""section"" id=""about"">
                  <div class=""container"">
                    <div class=""card"" data-aos=""fade-up"" data-aos-offset=""10"">
                      <div class=""row"">
                        <div class=""col-lg-6 col-md-12"">
                          <div class=""card-body"">
                            <div class=""h4 mt-0 title"">Про мене</div>
                            <p>{about}</p>
                          </div>
                        </div>
                        <div class=""col-lg-6 col-md-12"">
                          <div class=""card-body"">
                            <div class=""h4 mt-0 title"">Основна інформація</div>
                            <div class=""row"">
                              <div class=""col-sm-4""><strong class=""text-uppercase"">Дата народження:</strong></div>
                              <div class=""col-sm-8"">{data}</div>
                            </div>
                            <div class=""row mt-3"">
                              <div class=""col-sm-4""><strong class=""text-uppercase"">Емайл:</strong></div>
                              <div class=""col-sm-8"">{email}</div>
                            </div>
                            <div class=""row mt-3"">
                              <div class=""col-sm-4""><strong class=""text-uppercase"">Телефон:</strong></div>
                              <div class=""col-sm-8"">{phone}</div>
                            </div>
                            <div class=""row mt-3"">
                              <div class=""col-sm-4""><strong class=""text-uppercase"">Стать:</strong></div>
                              <div class=""col-sm-8"">{sex}</div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>



                <div class=""section"" id=""experience"">
                  <div class=""container cc-experience"">
                    <div class=""h4 text-center mb-4 title"">Досвід роботи</div>
                    <div class=""card"">
                      <div class=""row"">
                        <div class=""col-md-3 bg-primary"" data-aos=""fade-right"" data-aos-offset=""50"" data-aos-duration=""500"">
                          <div class=""card-body cc-experience-header"">
                            <div class=""h5"">{city}</div>
                          </div>
                        </div>
                        <div class=""col-md-9"" data-aos=""fade-left"" data-aos-offset=""50"" data-aos-duration=""500"">
                          <div class=""card-body"">
                            <div class=""h5"">{posada}</div>
                            <p>{opis}</p>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <div class=""section"" id=""Education"">
                  <div class=""container cc-education"">
                    <div class=""h4 text-center mb-4 title"">Освіта</div>
                    <div class=""card"">
                      <div class=""row"">
                        <div class=""col-md-3 bg-primary"" data-aos=""fade-right"" data-aos-offset=""50"" data-aos-duration=""500"">
                          <div class=""card-body cc-education-header"">
                            <div class=""h5"">Навчальний заклад</div>
                          </div>
                        </div>
                        <div class=""col-md-9"" data-aos=""fade-left"" data-aos-offset=""50"" data-aos-duration=""500"">
                          <div class=""card-body"">
                            <div class=""h5"">{navchalka}</div>
                            <p class=""category"">{facult}</p>
                            <p>Рівень овсіти: {studylvl}</p>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                    <script src=""js/core/jquery.3.2.1.min.js?ver=1.1.0""></script>
                    <script src=""js/core/popper.min.js?ver=1.1.0""></script>
                    <script src=""js/core/bootstrap.min.js?ver=1.1.0""></script>
                    <script src=""js/now-ui-kit.js?ver=1.1.0""></script>
                    <script src=""js/aos.js?ver=1.1.0""></script>
                    <script src=""scripts/main.js?ver=1.1.0""></script>
                  </body>
                </html>

                    ";

            File.WriteAllText(pathToData + "html\\" + "style4\\" + "index.html", html);

            Process.Start(new ProcessStartInfo(pathToData + "html\\" + "style4\\" + "index.html") { UseShellExecute = true });
        }
    }
}
