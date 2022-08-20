from csv import DictReader
import sys


def main():
    """main function"""
    # arg_count = len(sys.argv)
    # print(arg_count)
    lecturers_dict = {}
    with open(sys.argv[1], 'r') as csv_file:
        # csv_reader = reader(csv_file)
        # header = next(csv_reader)
        # if header is None:
        #     return
        # for row in csv_reader:
        #     course_name, course_num, lecturer, lesson_type, email, site = row
        csv_dict_reader = DictReader(csv_file)
        column_names = csv_dict_reader.fieldnames
        for row in csv_dict_reader:
            course_name = row[column_names[0]]
            course_num = row[column_names[1]]
            lecturer = row[column_names[2]]
            lesson_type = row[column_names[3]]
            email = row[column_names[4]]
            website = row[column_names[5]]
            course = Course(course_num, course_name)
            if lecturer not in lecturers_dict:
                lecturers_dict[lecturer] = Lecturer(lecturer, email, website)
            lecturers_dict[lecturer].courses.append(course)
    for lect in lecturers_dict.values():
        school = lect.courses[0].course_number[:4]
        # if school == "0321":
        #     lect.faculty = "פיזיקה ואסטרונומיה"
        # elif school == "0341":
        #     lect.faculty = "גאופיזיקה"
        # elif school == "0349":
        #     lect.faculty = "גאוגרפיה וסביבת האדם"
        # elif school == "0351":
        #     lect.faculty = "כימיה"
        # elif school == "0365":
        #     lect.faculty = "סטטיסטיקה וחקר ביצועים"
        # elif school == "0366":
        #     lect.faculty = "מתמטיקה"
        # elif school == "0368":
        #     lect.faculty = "מדעי המחשב"
        # elif school == "0372":
        #     lect.faculty = "מתמטיקה שימושית"
        switcher = {
            "0321": "פיזיקה ואסטרונומיה",
            "0341": "גאופיזיקה",
            "0349": "גאוגרפיה וסביבת האדם",
            "0351": "כימיה",
            "0365": "סטטיסטיקה וחקר ביצועים",
            "0366": "מתמטיקה",
            "0368": "מדעי המחשב",
            "0372": "מתמטיקה שימושית",
        }
        lect.faculty = switcher.get(school, "מדעים מדויקים")
        # scls_set = set([course.course_number[:4] for course in lect.courses])
        # if len(scls_set) > 1:
        #     print(lect.name)
    lecturers_dict["ד״ר אלון רון"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["ד״ר יואב לחיני"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["ד״ר נעמי אופנהיימר"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["פרופ׳ רועי בק–ברקאי"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["פרופ׳ יורם זלצר"].faculty = "כימיה"
    lecturers_dict["פרופ׳ יעל רוכמן"].faculty = "כימיה"
    lecturers_dict["פרופ׳ עמיר לוינסון"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["ד״ר ישראל חיים שק"].faculty = "כימיה"
    lecturers_dict["מר אבי חנן"].faculty = "מתמטיקה"
    lecturers_dict["ד״ר שלומי רובינשטיין"].faculty = "מתמטיקה"
    lecturers_dict["מר ראמי נאסר"].faculty = "מדעי המחשב"
    lecturers_dict["פרופ׳ אילון סולן"].faculty = "סטטיסטיקה וחקר ביצועים"
    lecturers_dict["ד״ר יעקוב יעקובוב"].faculty = "מתמטיקה שימושית"
    lecturers_dict["ד״ר רני הוד"].faculty = "מדעי המחשב"
    lecturers_dict["ד״ר ניר שרון"].faculty = "מתמטיקה שימושית"
    lecturers_dict["ד״ר דמיטרי בטנקוב"].faculty = "מתמטיקה שימושית"
    lecturers_dict["פרופ׳ חיים אברון"].faculty = "מתמטיקה שימושית"
    lecturers_dict["פרופ׳ יואל שקולניצקי"].faculty = "מתמטיקה שימושית"
    lecturers_dict["פרופ׳ עדי דיטקובסקי"].faculty = "מתמטיקה שימושית"
    lecturers_dict["פרופ׳ סטיבן שוחט"].faculty = "מתמטיקה שימושית"
    lecturers_dict["מר אלון בק"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["מר מוחמד ערו"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["פרופ׳ ברק ווייס"].faculty = "מתמטיקה"
    lecturers_dict["מר יונתן דוד גרשוני"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["ד״ר ברוך זיו"].faculty = "גאופיזיקה"
    lecturers_dict["ד״ר גלית אשכנזי–גולן"].faculty = "סטטיסטיקה וחקר ביצועים"
    lecturers_dict["ד״ר רן יצחק סניטקובסקי"].faculty = "סטטיסטיקה וחקר ביצועים"
    lecturers_dict["מר ניר קרת"].faculty = "מתמטיקה"
    lecturers_dict["גב׳ לי מאירה גפטר"].faculty = "סטטיסטיקה וחקר ביצועים"
    lecturers_dict["מר גיורא שמחוני"].faculty = "מתמטיקה"
    lecturers_dict["פרופ׳ סהרון רוסט"].faculty = "סטטיסטיקה וחקר ביצועים"
    lecturers_dict["גב׳ לילך פרי"].faculty = "מדעי המחשב"
    lecturers_dict["מר אור גוטליב"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["מר איתמר כהן"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["מר אמיתי כסלו"].faculty = "מתמטיקה"
    lecturers_dict["פרופ׳ רנן ברקנא"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["מר תום אהרן עיט"].faculty = "מדעי המחשב"
    lecturers_dict["פרופ׳ הלינה אברמוביץ"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["ד״ר משה בן־שלום"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["פרופ׳ ניר סוכן"].faculty = "מתמטיקה שימושית"
    lecturers_dict["מר תום לוי"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["פרופ׳ אלכסנדר פלבסקי"].faculty = "פיזיקה ואסטרונומיה"
    lecturers_dict["פרופ׳ אבנר סופר"].faculty = "פיזיקה ואסטרונומיה"
    with open(sys.argv[2], 'w') as json_file:
        json_file.write(str(sorted(lecturers_dict.values())))

    # mavo = Course("0368-1105", "מבוא מורחב למדעי המחשב")
    # bdida = Course("0368-1118", "מתמטיקה בדידה")
    # hedva = Course("0366-1101", "חשבון דיפרנציאלי ואינטגרלי 1א")
    # tomas = Course("0366-2140", "תורת המספרים")
    # amir = Lecturer("ד״ר אמיר רובינשטיין", "amirr@tau.ac.il",
    #                 "https://www.cs.tau.ac.il/~amirr")
    # amir.faculty = "מדעי המחשב"
    # amir.courses.append(mavo)
    # amir.courses.append(bdida)
    # asaf = Lecturer("פרופ׳ אסף נחמיאס", "asafnach@tauex.tau.ac.il", "")
    # asaf.faculty = "מתמטיקה"
    # asaf.courses.append(hedva)
    # david = Lecturer("פרופ׳ דוד סודרי", "soudry@tauex.tau.ac.il", "")
    # david.faculty = "מתמטיקה"
    # david.courses.append(tomas)
    # lecturers_lst = [amir, asaf, david]
    # print(lecturers_lst)


class Course:
    """Course class"""

    def __init__(self, course_number: str, course_name: str) -> None:
        self.course_number = course_number
        self.course_name = course_name

    def __repr__(self) -> str:
        return f'''
        {{
            "courseNumber" : "{self.course_number}",
            "courseName" : "{self.course_name}"
        }}'''


class Lecturer:
    """Lecturer class"""

    def __init__(self, name: str, email_addr: str, website_addr: str) -> None:
        self.name = name
        self.faculty = "מדעים מדויקים"
        self.email_addr = email_addr
        self.website_addr = website_addr
        self.courses = []

    def __lt__(self, other):
        if not hasattr(other, "name"):
            return NotImplemented
        return self.name < other.name
        # if not hasattr(other, "courses"):
        #     return NotImplemented
        # return len(self.courses) < len(other.courses)

    def __repr__(self) -> str:
        return f'''
{{
    "Name" : "{self.name}",
    "Faculty" : "{self.faculty}",
    "EmailAddr" : "{self.email_addr}",
    "WebsiteAddr" : "{self.website_addr}",
    "Courses" : {self.courses}
}}'''


if __name__ == "__main__":
    main()
