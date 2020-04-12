#Web scraping program to pull data from infinite scrolling webpage
#Probably overly commented due to my lack of Python/webscraping experience

#pip3 imports
import requests
import time
import csv
import pandas as pd
from pathlib import Path

#BeautifulSoup4 imports (making raw data easier to parse/configure
from bs4 import BeautifulSoup

#Selenium imports (can better check for nested devs and navigate pages better than BS4)
from selenium import webdriver

#Data path for output
DATA_PATH = Path('C:/Users/adam/Documents/Adam/Projects/Apps/A-Congre-bility/')
output_csv = 'bills.csv'

#Using Google Chrome
browser = webdriver.Chrome()
#Website to scrape
browser.get('https://www.govtrack.us/congress/bills/browse?status=6,7,8&sort=-current_status_date')
#Allow time for initial page load
time.sleep(2)

#Variable to determine wait length to allow infinite scroll to load (in seconds)
scroll_wait = 2

#Get scroll height of webpage
last_height = browser.execute_script("return document.body.scrollHeight")

#While loop to fully open page (page has infinite scroll)
while True:
            #Scroll down to bottom
            browser.execute_script("window.scrollTo(0, document.body.scrollHeight);")

            #Wait to load page using variable defined above
            time.sleep(scroll_wait)

            #Calculate new scroll height and compare with last scroll height
            new_height = browser.execute_script("return document.body.scrollHeight")
            #If page is fully opened...
            if new_height == last_height:
                break
            #Else, modify variable value
            last_height = new_height

#Once page is fully expanded, begin scraping

#Pull page source
content = browser.page_source
#Make page source readable and specify html processor (lxml)
soup = BeautifulSoup(content, 'lxml')

#Results variable for all content in main div (maincontent ID) 
results = soup.find(id='maincontent')

#Create iteratable list of bills
bills = results.find_all('div', class_='result_item')

#Creating empty array to store data in to then convert to .csv
billInfo = []
#Convert individual bill blocks into a string
#Split strings at key points to pull relevant info
#Append array above with variables of relevant info
for bill in bills:
    billDescription = str(bill.text)
    billName = billDescription.split(':')[0]
    billBio = billDescription.split(':')[1]
    sponsor = billDescription.split(':')[2]
    introDate = sponsor.split('Introduced')[1]
    sponsor = sponsor.split(']')[0]
    sponsor += ']'
    introDate = introDate.split('Agreed')[0]
    billInfo.append((billName.lstrip(), billBio[:len(billBio)-9], sponsor, introDate))

#Send info to csv file defined earlier  
df = pd.DataFrame(billInfo, columns=['Bill Name','Bio Description', 'Sponsored By', 'Introduced On'])  
df.to_csv(DATA_PATH/output_csv, encoding='utf-8-sig', index = False)