using ClassLibraryLab10;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace TestLab10
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MusicalInstrumentConstuctorWithParams()
        {
            // Arrange
            MusicalInstrument expected = new MusicalInstrument("������", 2);

            //Act
            MusicalInstrument actual = new MusicalInstrument("������", 2);

            //Accert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.id.Number, actual.id.Number);
        }

        [TestMethod]
        public void MusicalInstrumentConstuctorWithoutParams()
        {

            // Arrange
            MusicalInstrument expected = new MusicalInstrument();

            //Act
            MusicalInstrument actual = new MusicalInstrument();

            //Accert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.id.Number, actual.id.Number);
        }

        [TestMethod]
        public void MusicalInstrumentCompareToEquals()
        {
            //Arrange
            MusicalInstrument m1 = new MusicalInstrument("������", 12);
            MusicalInstrument m2 = new MusicalInstrument("������", 12);

            //Act
            int actual = m1.CompareTo(m2);

            //Accert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void MusicalInstrumentCompareTo()
        {
            //Arrange
            MusicalInstrument m1 = new MusicalInstrument("����", 12);
            MusicalInstrument m2 = new MusicalInstrument("�������", 77);

            //Act
            int actual = m1.CompareTo(m2);

            //Accert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void MusicalInstrumentCompareToDifferentObj()
        {
            //Arrange
            MusicalInstrument m = new MusicalInstrument("�������������", 8);
            Student s = new Student();

            //Act
            int actual = m.CompareTo(s);

            //Accert
            Assert.AreEqual(-1, actual);
        }

        [TestMethod]
        public void MusicalInstrumentCompareToNull()
        {
            // Arrange
            MusicalInstrument m = new MusicalInstrument();

            // Act
            int actual = m.CompareTo(null);

            // Assert
            Assert.AreEqual(actual, -1);
        }

        [TestMethod]
        public void MusicalInstrumentNotEquals()
        {
            //Arrange
            MusicalInstrument m1 = new MusicalInstrument("����", 12);
            MusicalInstrument m2 = new MusicalInstrument("�������", 77);

            //Act
            bool result = m1.Equals(m2);

            //Accert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void MusicalInstrumentEqualsNull()
        {
            // Arrange
            MusicalInstrument m = new MusicalInstrument();

            // Act
            bool result = m.Equals(null);

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void MusicalInstrumentEqualsDifferentObj()
        {
            //Arrange
            MusicalInstrument m = new MusicalInstrument("�������������", 8);
            Student s = new Student();

            //Act
            bool result = m.Equals(s);

            //Accert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void MusicalInstrumentEquals()
        {
            //Arrange
            MusicalInstrument m1 = new MusicalInstrument();
            MusicalInstrument m2 = new MusicalInstrument();

            //Act
            bool result1 = m1.Name.Equals(m2.Name);
            bool result2 = m1.id.Equals(m2.id);

            //Accert
            Assert.AreEqual(result1, result2);
        }

        [TestMethod]
        public void MusicalInstrumentNotEqualsName()
        {
            //Arrange
            MusicalInstrument m1 = new MusicalInstrument("����", 12);
            MusicalInstrument m2 = new MusicalInstrument("�������", 12);

            //Act
            bool result = m1.Equals(m2);

            //Accert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void MusicalInstrumentNotEqualsId()
        {
            //Arrange
            MusicalInstrument m1 = new MusicalInstrument("����", 12);
            MusicalInstrument m2 = new MusicalInstrument("����", 47);

            //Act
            bool result = m1.Equals(m2);

            //Accert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void MusicalInstrumentToStirng()
        {
            //Arrange
            MusicalInstrument m = new MusicalInstrument("����", 58);
            string expected = "58: ����,";

            //Act
            string result = m.ToString();

            //Accert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MusicalInstrumentCLone()
        {
            //Arrange
            MusicalInstrument m = new MusicalInstrument("����", 58);

            //Act
            MusicalInstrument clon = m.Clone() as MusicalInstrument;

            //Accert
            Assert.AreEqual(m.Name, clon.Name);
            Assert.AreEqual(m.id, clon.id);
        }

        [TestMethod]
        public void MusicalInstrumentCopy()
        {
            //Arrange
            MusicalInstrument m = new MusicalInstrument("����", 58);

            //Act
            MusicalInstrument copy = m.ShallowCopy() as MusicalInstrument;

            //Accert
            Assert.AreEqual(m.Name, copy.Name);
            Assert.AreEqual(m.id, copy.id);
        }

        [TestMethod]
        public void IdNumberException()
        {
            // Arrange 
            IdNumber n = new IdNumber();

            //Act
            try
            {
                n.Number = -7;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������! �������� ��� ���� number ������ ���� ������ 0", ex.Message);
            }
        }

        [TestMethod]
        public void IdNumberEqualDifferentObj()
        {

            //Arrange
            IdNumber n = new IdNumber();
            Student s = new Student();

            //Act
            bool result = n.Equals(s);

            //Accert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GuitarException()
        {
            // Arrange 
            Guitar g = new Guitar();

            //Act
            try
            {
                g.StringsNumber = -7;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������! �������� ��� ���� stringsNumber ������ ���� � ���������� �� 0 �� 20", ex.Message);
            }
        }

        [TestMethod]
        public void GuitarConstuctorWithParams()
        {
            // Arrange
            Guitar expected = new Guitar("������", 2, 52);

            //Act
            Guitar actual = new Guitar("������", 2, 52);

            //Accert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.id.Number, actual.id.Number);
            Assert.AreEqual(expected.StringsNumber, actual.StringsNumber);
        }

        [TestMethod]
        public void GuitarToStirng()
        {
            //Arrange
            Guitar g = new Guitar("������", 4, 77);
            string expected = "77: ������, 4 �����";

            //Act
            string result = g.ToString();

            //Accert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GuitarEquals()
        {
            //Arrange
            Guitar g1 = new Guitar("������", 4, 77);
            Guitar g2 = new Guitar("������", 4, 77);

            //Act
            bool result = g1.Equals(g2);

            //Accert
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void GuitarNotEquals()
        {
            //Arrange
            Guitar g1 = new Guitar("������", 4, 77);
            Guitar g2 = new Guitar("������", 3, 44);

            //Act
            bool result = g1.Equals(g2);

            //Accert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void GuitarEqualsNull()
        {
            // Arrange
            Guitar g = new Guitar();

            // Act
            bool result = g.Equals(null);

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void GuitarEqualsDifferentObj()
        {
            //Arrange
            Guitar g = new Guitar();
            Student s = new Student();

            //Act
            bool result = g.Equals(s);

            //Accert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ElectricGuitarConstuctorWithParams()
        {
            // Arrange
            ElectricGuitar expected = new ElectricGuitar("�������������", 2, "�����������", 33);

            //Act
            ElectricGuitar actual = new ElectricGuitar("�������������", 2, "�����������", 33);

            //Accert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.id.Number, actual.id.Number);
            Assert.AreEqual(expected.PowerSupply, actual.PowerSupply);
            Assert.AreEqual(expected.StringsNumber, actual.StringsNumber);
        }

        [TestMethod]
        public void ElectricGuitarConstuctorWithoutParams()
        {
            // Arrange
            ElectricGuitar expected = new ElectricGuitar();

            //Act
            ElectricGuitar actual = new ElectricGuitar();

            //Accert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.id.Number, actual.id.Number);
            Assert.AreEqual(expected.PowerSupply, actual.PowerSupply);
            Assert.AreEqual(expected.StringsNumber, actual.StringsNumber);
        }

        [TestMethod]
        public void ElectricGuitarToStirng()
        {
            //Arrange
            ElectricGuitar e = new ElectricGuitar("�������������", 6, "�����������", 22);
            string expected = "22: �������������, 6 �����, �������� �� �����������";

            //Act
            string result = e.ToString();

            //Accert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ElectricGuitarNotEquals()
        {
            //Arrange
            ElectricGuitar e1 = new ElectricGuitar("�������������", 6, "�����������", 22);
            ElectricGuitar e2 = new ElectricGuitar("�������������", 4, "���������", 19);

            //Act
            bool result = e1.Equals(e2);

            //Accert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void ElectricGuitarEqualsNull()
        {
            // Arrange
            ElectricGuitar e = new ElectricGuitar();

            // Act
            bool result = e.Equals(null);

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void ElectricGuitarEqualsDifferentObj()
        {
            //Arrange
            ElectricGuitar e = new ElectricGuitar();
            Student s = new Student();

            //Act
            bool result = e.Equals(s);

            //Accert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void PianoException()
        {
            // Arrange 
            Piano p = new Piano();

            //Act
            try
            {
                p.KeysNumber = -1;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������! �������� ��� ���� keysNumber ������ ���� ������ 0", ex.Message);
            }
        }

        [TestMethod]
        public void PianoConstuctorWithParams()
        {
            // Arrange
            Piano expected = new Piano("����������", "��������", 80, 33);

            //Act
            Piano actual = new Piano("����������", "��������", 80, 33);

            //Accert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.id.Number, actual.id.Number);
            Assert.AreEqual(expected.KeyLayout, actual.KeyLayout);
            Assert.AreEqual(expected.KeysNumber, actual.KeysNumber);
        }

        [TestMethod]
        public void PianoToStirng()
        {
            //Arrange
            Piano p = new Piano("����������", "��������", 80, 33);
            string expected = "33: ����������, �������� ���������, 80 ������";

            //Act
            string result = p.ToString();

            //Accert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PianoNotEquals()
        {
            //Arrange
            Piano p1 = new Piano("����������", "�����������", 70, 15);
            Piano p2 = new Piano("����������", "�����������", 45, 85);

            //Act
            bool result = p1.Equals(p2);

            //Accert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void PianoEqualsNull()
        {
            // Arrange
            Piano p = new Piano();

            // Act
            bool result = p.Equals(null);

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void PianoEqualsDifferentObj()
        {
            //Arrange
            Piano p = new Piano();
            Student s = new Student();

            //Act
            bool result = p.Equals(s);

            //Accert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void PianoEquals()
        {
            //Arrange
            Piano p1 = new Piano("����������", "�����������", 70, 15);
            Piano p2 = new Piano("����������", "�����������", 70, 15);

            //Act
            bool result1 = p1.KeysNumber.Equals(p2.KeysNumber);
            bool result2 = p1.KeyLayout.Equals(p2.KeyLayout);

            //Accert
            Assert.AreEqual(result1, result2);
        }

        [TestMethod]
        public void StudentConstructorWithParametrs()
        {
            // Arrange
            Student expected = new Student("Jon", 20, 5.5);

            //Act
            Student actual = new Student("Jon", 20, 5.5);

            //Accert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void StudentCopyConstructor()
        {
            // Arrange
            Student expected = new Student("Jon", 20, 3.5);

            //Act
            Student actual = new Student(expected);

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StudentExceptionAge1()
        {
            // Arrange 
            Student person = new Student("Jon", 20, 5.5);

            //Act
            try
            {
                person.Age = 180;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������! �������� ��� ���� age �� ������ ���� ������  0 ��� ������ 100", ex.Message);
            }
        }

        [TestMethod]
        public void StudentExceptionAge2()
        {
            // Arrange 
            Student person = new Student("Jon", 20, 5.5);

            //Act
            try
            {
                person.Age = -3;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������! �������� ��� ���� age �� ������ ���� ������  0 ��� ������ 100", ex.Message);
            }
        }

        [TestMethod]
        public void StudentExceptionGpa1()
        {
            // Arrange 
            Student person = new Student("Jon", 20, 5.5);

            //Act
            try
            {
                person.Gpa = 12;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������! �������� ��� ���� gpa ������ ���� � ���������� �� 0 �� 10", ex.Message);
            }
        }

        [TestMethod]
        public void StudentExceptionGpa2()
        {
            // Arrange 
            Student person = new Student("Jon", 20, 5.5);

            //Act
            try
            {
                person.Gpa = -3;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("������! �������� ��� ���� gpa ������ ���� � ���������� �� 0 �� 10", ex.Message);
            }
        }

        [TestMethod]
        public void StudentToStirng()
        {
            //Arrange
            Student s = new Student("Jon", 20, 5.5);
            string expected = "���: Jon, �������: 20, gpa: 5,5";

            //Act
            string result = s.ToString();

            //Accert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void StudentNotEquals()
        {
            //Arrange
            Student s1 = new Student("Jon", 20, 5.5);
            Student s2 = new Student("Jon", 17, 7.1);

            //Act
            bool result = s1.Equals(s2);

            //Accert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void StudentEqualsNull()
        {
            // Arrange
            Student s = new Student();

            // Act
            bool result = s.Equals(null);

            // Assert
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void StudentEqualsDifferentObj()
        {
            //Arrange
            Piano p = new Piano();
            Student s = new Student();

            //Act
            bool result = s.Equals(p);

            //Accert
            Assert.AreEqual(false, result);
        }
    }
}